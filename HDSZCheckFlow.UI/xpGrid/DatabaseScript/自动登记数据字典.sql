select TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty into #xpGrid_Columns from xpGrid_Columns where 1=2
insert into #xpGrid_Columns(TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty)
SELECT o.name AS TableName, c.name AS ColumnName, 
      UPPER(t.name) AS DatatypeName, c.length, c.xprec, 
      c.xscale, c.isnullable AS Nullable, 
      c.cdefault AS ColDefault, c.name AS DisplayLabel, 
      100 AS DisplayOrder, 0 AS DisplayWidth, '' AS DisplayFormat, '' AS EditFormat, 
      '' AS ColVarify, '' AS VarifyMsg, 2 AS ColVisible
	, case when (select COLUMN_NAME = convert(sysname, c.name) from sysindexes i
		where o.id = c.id
		and o.id = i.id
		and (i.status & 0x800) = 0x800
		and (c.name = index_col (o.name, i.indid,  1) or
		     c.name = index_col (o.name, i.indid,  2) or
		     c.name = index_col (o.name, i.indid,  3) or
		     c.name = index_col (o.name, i.indid,  4) or
		     c.name = index_col (o.name, i.indid,  5) or
		     c.name = index_col (o.name, i.indid,  6) or
		     c.name = index_col (o.name, i.indid,  7) or
		     c.name = index_col (o.name, i.indid,  8) or
		     c.name = index_col (o.name, i.indid,  9) or
		     c.name = index_col (o.name, i.indid, 10) or
		     c.name = index_col (o.name, i.indid, 11) or
		     c.name = index_col (o.name, i.indid, 12) or
		     c.name = index_col (o.name, i.indid, 13) or
		     c.name = index_col (o.name, i.indid, 14) or
		     c.name = index_col (o.name, i.indid, 15) or
		     c.name = index_col (o.name, i.indid, 16)
		    )) is null then 2 else 1 end as ColProperty
FROM syscolumns c INNER JOIN
      sysobjects o ON c.id = o.id INNER JOIN
      systypes t ON c.xtype = t.xtype
WHERE (c.id IN
          (SELECT id
         FROM sysobjects
         WHERE xtype = 'u' AND name NOT IN
                   (SELECT tablename
                  FROM xpGrid_Tables))) AND (o.xtype = 'u') AND 
      (UPPER(t.name) <> 'SYSNAME') and o.name <> 'dtproperties'
select * from #xpGrid_Columns

insert into xpGrid_Tables(TableName, TableTypeID, TableOrder, TableLabel, TableVisible)
select name, case when [name] like 'xpgrid_%' then 1 else 3 end, 1, name, 2 from sysobjects where xtype = 'u' and name not in(select tablename from xpGrid_Tables) and sysobjects.name <> 'dtproperties'

insert into xpGrid_Columns(TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty)
select TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty from #xpGrid_Columns where datatype <> 'SYSNAME'
drop table #xpGrid_Columns

