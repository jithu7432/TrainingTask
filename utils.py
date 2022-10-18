import pandas as pd

def preprocess(df: pd.DataFrame) -> pd.DataFrame:
    df['ChargingStatus'] -= 1
    return df

def calculate_overcharged(df: pd.DataFrame) -> list[dict[str, int]]:
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
        elif toggled and (plugged[i] == 0 or (i + 1) == ns):
            r = timestamp[i-1]
            if count > 0:
                dat = dict(start=l, end=r)
                cout.append(dat)
                count = 0
                l = r = None
                toggled = False
        i += 1
    return cout

def compute_counts(df: pd.DataFrame, arr: dict[str, int]) -> dict: #type: ignore
    cout = { "BadCount" : 0, "OptimalCount" : 0, "SpotCount" : 0, }
    for x in arr:
        temp = df[df.TimeStamp.between(x['start'], x['end'])] #type: ignore
        ns = len(temp.index)
        if temp.CurrentLevel.max() < 100:
            cout["SpotCount"] += 1
            continue
        if ns <= 30:
            cout["OptimalCount"] += 1
            continue
        if ns > 30:
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
            if g > 30:
                cout["BadCount"] += 1
        return cout








