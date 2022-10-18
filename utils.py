import pandas as pd

def preprocess(df: pd.DataFrame) -> pd.DataFrame:
    df['ChargingStatus'] -= 1
    df.drop_duplicates(subset=['TimeStamp'], inplace=True) 
    df.reset_index(drop=True, inplace=True)
    return df

def preprocess_minute(stock: pd.DataFrame) -> pd.DataFrame:
    df = stock[::-1] # SQL sorts and returns in desc order.
    df.reset_index(drop=True, inplace=True)
    return df

def compute_decrement(df: pd.DataFrame):
    level = df.CurrentLevel.values
    timestamp = df.TimeStamp.values
    ns = len(level)

    if ns < 60: raise Exception("Not enough values to process!")

    cout = [(level[0], timestamp[0])]
    i = 1
    while i < ns:
        if level[i-1] > level[i]:
            cout.append((level[i], timestamp[i]))
        elif level[i-1] < level[i]:
            cout.append((level[i], timestamp[i]))
        i += 1

    nt = len(cout)
    drop = time = 0 
    j = 1
    while j < nt:
        curr = cout[j]
        prev = cout[j - 1]
        if prev[0] > curr[0]:
            drop += (prev[0] - curr[0])
            time += (curr[1] - prev[1])
        j += 1
    return drop, time 

def calculate_charging_bounds(df: pd.DataFrame) -> list[dict[str, int]]:
    plugged = df.ChargingStatus.values
    timestamp = df.TimeStamp.values

    ns = len(df.index)
    count = 0
    cout = []
    toggled = False
    l = r = None
    i = 0
    while i < ns:
        if not toggled and plugged[i] == 1:
            toggled = True
            l = timestamp[i]
        if toggled and plugged[i] == 1:
            count += 1
        elif toggled and (plugged[i] != 1 or (i + 1) == ns):
            r = timestamp[i-1]
            if count > 0:
                dat = dict(start=l, end=r)
                cout.append(dat)
                count = 0
                l = r = None
                toggled = False
        i += 1
    return cout

def classify_counts(df: pd.DataFrame, arr: dict[str, int]) -> dict: #type: ignore
    cout = { "BadCount" : 0, "OptimalCount" : 0, "SpotCount" : 0, }
    for x in arr:
        temp = df[df.TimeStamp.between(x['start'], x['end'])] #type: ignore
        ns = len(temp.index)
        if temp.CurrentLevel.max() < 100:
            cout["SpotCount"] += 1
        else:
            levels = temp.CurrentLevel.values
            g = c = i = 0
            while i < ns:
                if levels[i] == 100:
                    c += 1 
                else:
                    g = max(g, c)
                    c = 0
                i += 1
                if i + 1 == ns:
                    g = max(g, c)
            if g > 1800:
                cout["BadCount"] += 1
            else:
                cout["OptimalCount"] += 1
    return cout
