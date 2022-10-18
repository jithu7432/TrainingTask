#!/usr/bin/env python

import utils
import sqlalchemy
import pandas as pd

from sqlalchemy.engine import URL
from sqlalchemy import create_engine

def main():
    connection_string = "DRIVER={SQL Server Native Client 11.0};SERVER=(localdb)\mssqllocaldb;DATABASE=Battery;TrustedConnection=yes"
    connection_url = URL.create("mssql+pyodbc", query={"odbc_connect": connection_string})
    engine = create_engine(connection_url)

    # 1: 
    SQL = "SELECT * FROM Daemon ORDER BY [TimeStamp]"
    df = pd.read_sql(SQL, engine)
    df = utils.preprocess(df)
    bounds = utils.calculate_charging_bounds(df) 
    cout = utils.classify_counts(df, bounds)
    print(cout)

    #2:
    SQL = "SELECT TOP (3600) * FROM Daemon ORDER BY [TimeStamp] DESC"
    df = pd.read_sql(SQL, engine)
    df = utils.preprocess_minute(df)
    cout = utils.compute_decrement(df)
    print(cout)


if __name__ == "__main__":
    main()
