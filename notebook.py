#!/usr/bin/env python

import utils
import pandas as pd

from utils import calculate_overcharged as calc
from utils import compute_counts as comp 

_df = pd.read_csv('test.csv')
_df.sort_values(by='TimeStamp', ascending=True, inplace=True) #type: ignore
_df.drop_duplicates(subset=['TimeStamp'], inplace=True) #type: ignore
_df.reset_index(drop=True, inplace=True) #type: ignore

df = _df.copy() #type: ignore
utils.preprocess(df)

dat = calc(df)

temp = comp(df, dat) #type: ignore
print(temp)
