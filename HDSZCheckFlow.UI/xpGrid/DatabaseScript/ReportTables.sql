if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_Reports_BM_RptClass]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_Reports] DROP CONSTRAINT FK_xpGrid_Reports_BM_RptClass
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_Reports_BM_RptType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_Reports] DROP CONSTRAINT FK_xpGrid_Reports_BM_RptType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BM_RptClass]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BM_RptClass]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BM_RptType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BM_RptType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Reports]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Reports]
GO

CREATE TABLE [BM_RptClass] (
	[BM0000] [int] IDENTITY (1, 1) NOT NULL ,
	[MC0000] [varchar] (40) NOT NULL ,
	[PARENTBM] [int] NULL ,
	CONSTRAINT [PK_BM_RptClass] PRIMARY KEY  CLUSTERED 
	(
		[BM0000]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


CREATE TABLE [BM_RptType] (
	[BM0000] [int] IDENTITY (1, 1) NOT NULL ,
	[MC0000] [varchar] (40) NOT NULL ,
	[PARENTBM] [char] (2) NULL ,
	CONSTRAINT [pk_BM_RptType] PRIMARY KEY  CLUSTERED 
	(
		[BM0000]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO


CREATE TABLE [xpGrid_Reports] (
	[Rpt_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Rpt_Name] [varchar] (50) NOT NULL ,
	[Rpt_Class] [int] NOT NULL ,
	[Rpt_Type] [int] NOT NULL ,--1=空表  2=简单表  3=分组表  4=交叉表
	Rpt_GroupInfo varchar(1024),
	[Rpt_SQL] [text] NOT NULL ,
	Rpt_Params varchar(2048),
	[Rpt_XML] [text] NOT NULL ,
	CONSTRAINT [pk_xpGrid_Reports] PRIMARY KEY  CLUSTERED 
	(
		[Rpt_ID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_xpGrid_Reports_BM_RptClass] FOREIGN KEY 
	(
		[Rpt_Class]
	) REFERENCES [BM_RptClass] (
		[BM0000]
	) ON UPDATE CASCADE 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'BM_RptClass' , 2 , 0 , '报表类别表' , 2 )
INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'BM_RptType' , 2 , 0 , '报表类别表' , 2 )
INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_Reports' , 1 , 0 , 'xpGrid_Reports' , 2 )

INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptClass' , 'BM0000' , 'INT IDENTITY' , 4 , 10 , 0 , '' , '编码' , 1 , 0 , '' , '' , '' , '' , 2 , 1 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptClass' , 'MC0000' , 'VARCHAR' , 40 , 0 , 0 , '' , '名称' , 2 , 0 , '' , '' , '' , '' , 2 , 2 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptClass' , 'PARENTBM' , 'INT' , 4 , 10 , 1 , '' , '父编码' , 3 , 0 , '' , '' , '' , '' , 2 , 2 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptType' , 'BM0000' , 'INT IDENTITY' , 4 , 10 , 0 , '' , '编码' , 1 , 0 , '' , '' , '' , '' , 2 , 1 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptType' , 'MC0000' , 'VARCHAR' , 40 , 0 , 0 , '' , '名称' , 2 , 0 , '' , '' , '' , '' , 2 , 2 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_RptType' , 'PARENTBM' , 'INT' , 4 , 10 , 1 , '' , '父编码' , 3 , 0 , '' , '' , '' , '' , 2 , 2 )

INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_ID' , 'INT IDENTITY' , 4 , 0 , 0 , '' , 'Rpt_ID' , 0 , 0 , '' , '' , '' , '' , 2 , 1 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_Name' , 'VARCHAR' , 50 , 0 , 0 , '' , 'Rpt_Name' , 0 , 0 , '' , '' , '' , '' , 2 , 3 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_Class' , 'INT' , 4 , 0 , 0 , '' , 'Rpt_Class' , 0 , 0 , '' , '' , '' , '' , 2 , 3 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_Type' , 'INT' , 4 , 0 , 0 , '' , 'Rpt_Type' , 0 , 0 , '' , '' , '' , '' , 2 , 3 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_SQL' , 'TEXT' , 16 , 0 , 0 , '' , 'Rpt_SQL' , 0 , 0 , '' , '' , '' , '' , 2 , 3 )
INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_Reports' , 'Rpt_XML' , 'TEXT' , 16 , 0 , 0 , '' , 'Rpt_XML' , 0 , 0 , '' , '' , '' , '' , 2 , 3 )

INSERT [BM_RptType] ( [MC0000] ) VALUES (  '空表' )
INSERT [BM_RptType] ( [MC0000] ) VALUES (  '简单表' )
INSERT [BM_RptType] ( [MC0000] ) VALUES (  '分组表' )
INSERT [BM_RptType] ( [MC0000] ) VALUES (  '交叉表' )



 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent] ) VALUES ( '0012' , 'XpGrid报表' , '00' )
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent] ) VALUES ( '001201' , 'XpGrid报表' , 'Reports/ReportView.aspx' , '0012' )

insert into BM_RptClass(MC0000) values('xpGrid样表')
insert into xpGrid_Reports(Rpt_Name, Rpt_Class, Rpt_Type, Rpt_GroupInfo, Rpt_SQL, Rpt_Params, Rpt_XML) 
	values('分组报表', 1, 2, '分组1,TEST_XPGRID_CODEINPUT|分组2,TEST_XPGRID_LOOKINPUT|', 'select * from test_xpgrid order by CodeInput, LookInput', 'aaaaa;;CHAR;;'';', )
