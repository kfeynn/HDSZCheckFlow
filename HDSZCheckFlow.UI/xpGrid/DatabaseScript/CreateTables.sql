if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Columns_xpGrid_ColumnsInRoles_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_ColumnsInRoles] DROP CONSTRAINT xpGrid_Columns_xpGrid_ColumnsInRoles_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Columns_xpGrid_QueryConditionItems_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QueryConditionItems] DROP CONSTRAINT xpGrid_Columns_xpGrid_QueryConditionItems_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Columns_xpGrid_QueryFields_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QueryFields] DROP CONSTRAINT xpGrid_Columns_xpGrid_QueryFields_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Columns_xpGrid_QuerySorts_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QuerySorts] DROP CONSTRAINT xpGrid_Columns_xpGrid_QuerySorts_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_FuncFrame_xpGrid_FunAssign_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_FuncsInRoles] DROP CONSTRAINT xpGrid_FuncFrame_xpGrid_FunAssign_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryConditionSets_Item_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QueryConditionItems] DROP CONSTRAINT xpGrid_QueryConditionSets_Item_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_QueryProjects_xpGrid_QueryConditionSets]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QueryProjects] DROP CONSTRAINT FK_xpGrid_QueryProjects_xpGrid_QueryConditionSets
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryProjects_xpGrid_ueryFields_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QueryFields] DROP CONSTRAINT xpGrid_QueryProjects_xpGrid_ueryFields_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryProjects_xpGrid_QuerySorts_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_QuerySorts] DROP CONSTRAINT xpGrid_QueryProjects_xpGrid_QuerySorts_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_ReportParams_xpGrid_Reports]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_ReportParams] DROP CONSTRAINT FK_xpGrid_ReportParams_xpGrid_Reports
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Role_xpGrid_ColumnsInRoles_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_ColumnsInRoles] DROP CONSTRAINT xpGrid_Role_xpGrid_ColumnsInRoles_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Role_xpGrid_FunAssign_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_FuncsInRoles] DROP CONSTRAINT xpGrid_Role_xpGrid_FunAssign_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Role_xpGrid_UsersInRoles_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_UsersInRoles] DROP CONSTRAINT xpGrid_Role_xpGrid_UsersInRoles_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_TableType_xpGrid_TableConstraint_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_TableConstraint] DROP CONSTRAINT xpGrid_TableType_xpGrid_TableConstraint_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_Tables_xpGrid_TableType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_Tables] DROP CONSTRAINT FK_xpGrid_Tables_xpGrid_TableType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_TableType_xpGrid_TableTemplate_FK1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_TableTemplate] DROP CONSTRAINT xpGrid_TableType_xpGrid_TableTem
plate_FK1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_Columns_xpGrid_Tables]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_Columns] DROP CONSTRAINT FK_xpGrid_Columns_xpGrid_Tables
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_DefaultField_xpGrid_User]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_DefaultField] DROP CONSTRAINT FK_xpGrid_DefaultField_xpGrid_User
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_xpGrid_UsersInRoles_xpGrid_User]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[xpGrid_UsersInRoles] DROP CONSTRAINT FK_xpGrid_UsersInRoles_xpGrid_User
GO

/****** Object:  Table [dbo].[xpGrid_Attachments]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Attachments]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Attachments]
GO

/****** Object:  Table [dbo].[xpGrid_Columns]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Columns]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Columns]
GO

/****** Object:  Table [dbo].[xpGrid_ColumnsInRoles]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ColumnsInRoles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_ColumnsInRoles]
GO

/****** Object:  Table [dbo].[xpGrid_Datatypes]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Datatypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Datatypes]
GO

/****** Object:  Table [dbo].[xpGrid_DefaultField]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_DefaultField]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_DefaultField]
GO

/****** Object:  Table [dbo].[xpGrid_FuncsInRoles]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_FuncsInRoles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_FuncsInRoles]
GO

/****** Object:  Table [dbo].[xpGrid_Functions]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Functions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Functions]
GO

/****** Object:  Table [dbo].[xpGrid_Images]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Images]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Images]
GO

/****** Object:  Table [dbo].[xpGrid_QueryConditionItems]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryConditionItems]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QueryConditionItems]
GO

/****** Object:  Table [dbo].[xpGrid_QueryConditionSets]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryConditionSets]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QueryConditionSets]
GO

/****** Object:  Table [dbo].[xpGrid_QueryFields]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryFields]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QueryFields]
GO

/****** Object:  Table [dbo].[xpGrid_QueryProjectClass]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryProjectClass]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QueryProjectClass]
GO

/****** Object:  Table [dbo].[xpGrid_QueryProjects]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QueryProjects]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QueryProjects]
GO

/****** Object:  Table [dbo].[xpGrid_QuerySavers]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QuerySavers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QuerySavers]
GO

/****** Object:  Table [dbo].[xpGrid_QuerySorts]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_QuerySorts]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_QuerySorts]
GO

/****** Object:  Table [dbo].[xpGrid_ReportParams]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ReportParams]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_ReportParams]
GO

/****** Object:  Table [dbo].[xpGrid_Reports]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Reports]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Reports]
GO

/****** Object:  Table [dbo].[xpGrid_Role]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Role]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Role]
GO

/****** Object:  Table [dbo].[xpGrid_TableConstraint]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_TableConstraint]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_TableConstraint]
GO

/****** Object:  Table [dbo].[xpGrid_TableTemplate]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_TableTemplate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_TableTemplate]
GO

/****** Object:  Table [dbo].[xpGrid_TableType]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_TableType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_TableType]
GO

/****** Object:  Table [dbo].[xpGrid_Tables]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_Tables]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_Tables]
GO

/****** Object:  Table [dbo].[xpGrid_User]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_User]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_User]
GO

/****** Object:  Table [dbo].[xpGrid_UsersInRoles]    Script Date: 2006-4-18 18:14:33 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_UsersInRoles]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xpGrid_UsersInRoles]
GO

/****** Object:  Table [dbo].[xpGrid_Attachments]    Script Date: 2006-4-18 18:14:38 ******/
CREATE TABLE [dbo].[xpGrid_Attachments] (
	[Attachment_id] [int] IDENTITY (1, 1) NOT NULL ,
	[Attachment_attachmentData] [image] NOT NULL ,
	[Attachment_fileName] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Attachment_contentType] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Attachment_Timestamp] [timestamp] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Columns]    Script Date: 2006-4-18 18:14:38 ******/
CREATE TABLE [dbo].[xpGrid_Columns] (
	[ColumnID] [int] IDENTITY (1, 1) NOT NULL ,
	[TableName] [varchar] (64) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[ColName] [varchar] (64) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[DataType] [varchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Length] [int] NULL ,
	[XPrec] [int] NULL ,
	[XScale] [int] NULL ,
	[Nullable] [int] NULL ,
	[ColDefault] [varchar] (60) COLLATE Chinese_PRC_CI_AS NULL ,
	[DisplayLabel] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[DisplayOrder] [int] NOT NULL ,
	[DisplayWidth] [int] NULL ,
	[DisplayFormat] [varchar] (80) COLLATE Chinese_PRC_CI_AS NULL ,
	[EditFormat] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[ColVarify] [varchar] (1024) COLLATE Chinese_PRC_CI_AS NULL ,
	[VarifyMsg] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ColVisible] [int] NULL ,
	[ColProperty] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_ColumnsInRoles]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_ColumnsInRoles] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RoleId] [int] NULL ,
	[ColumnID] [int] NULL ,
	[AllowEdit] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Datatypes]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_Datatypes] (
	[TypeName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[TypeLabel] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[XType] [smallint] NOT NULL ,
	[Length] [smallint] NOT NULL ,
	[XPrec] [tinyint] NOT NULL ,
	[XScale] [tinyint] NOT NULL ,
	[Allownulls] [bit] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_DefaultField]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_DefaultField] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[PageInfo] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[DefaultField] [varchar] (4000) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_FuncsInRoles]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_FuncsInRoles] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[RoleId] [int] NULL ,
	[FuncCode] [varchar] (30) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Functions]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_Functions] (
	[FuncCode] [varchar] (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[FuncName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[FuncUrl] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[FuncParent] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,
	[FuncImg] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Enable] [bit] default 1 not NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Images]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_Images] (
	[Image_id] [int] IDENTITY (1, 1) NOT NULL ,
	[Image_imageData] [image] NOT NULL ,
	[Image_fileName] [nvarchar] (250) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Image_contentType] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Image_SizedImageData] [image] NULL ,
	[Image_SizedImageWidth] [int] NOT NULL ,
	[Image_SizedImageHeight] [int] NOT NULL ,
	[Image_SizedImageIsThumbnail] [bit] NOT NULL ,
	[Image_Timestamp] [timestamp] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QueryConditionItems]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QueryConditionItems] (
	[ItemID] [int] IDENTITY (1, 1) NOT NULL ,
	[SetID] [int] NOT NULL ,
	[ColumnID] [int] NOT NULL ,
	[IsPre] [smallint] NOT NULL ,
	[Operator] [smallint] NOT NULL ,
	[ItemValue] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Caption] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[LabelNo] [int] NOT NULL ,
	[FunExp] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QueryConditionSets]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QueryConditionSets] (
	[SetID] [int] IDENTITY (1, 1) NOT NULL ,
	[SetCaption] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[LogicalExpression] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[SQLExpression] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QueryFields]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QueryFields] (
	[FieldID] [int] IDENTITY (1, 1) NOT NULL ,
	[SuiteID] [int] NOT NULL ,
	[ColumnID] [int] NOT NULL ,
	[OrderNo] [int] NULL ,
	[StatType] [smallint] NULL ,
	[Caption] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QueryProjectClass]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QueryProjectClass] (
	[ClassID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassName] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Description] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL ,
	[GroupCode] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QueryProjects]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QueryProjects] (
	[ProjectID] [int] IDENTITY (1, 1) NOT NULL ,
	[ProjectName] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[CondID] [int] NULL ,
	[QueryType] [smallint] NOT NULL ,
	[SQLDesc] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[TopNumber] [int] NULL ,
	[PageSize] [char] (10) COLLATE Chinese_PRC_CI_AS NULL ,
	[Description] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[GroupCode] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL ,
	[JoinType] [smallint] NULL ,
	[SortDesc] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[ClassID] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QuerySavers]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QuerySavers] (
	[SetID] [int] NOT NULL ,
	[UserID] [int] NOT NULL ,
	[Shared] [smallint] NULL ,
	[GroupCode] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL ,
	[SaverID] [int] IDENTITY (1, 1) NOT NULL ,
	[TableList] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ConExp] [text] COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_QuerySorts]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_QuerySorts] (
	[SortID] [int] IDENTITY (1, 1) NOT NULL ,
	[SuiteID] [int] NOT NULL ,
	[ColumnID] [int] NOT NULL ,
	[OrderNo] [int] NULL ,
	[Direction] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_ReportParams]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_ReportParams] (
	[ParamID] [int] IDENTITY (1, 1) NOT NULL ,
	[Rpt_ID] [int] NOT NULL ,
	[ParamName] [int] NOT NULL ,
	[DataType] [varchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Reports]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_Reports] (
	[Rpt_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Rpt_Name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Rpt_Class] [int] NOT NULL ,
	[Rpt_Type] [int] NOT NULL ,
	[Rpt_GroupInfo] [varchar] (1024) COLLATE Chinese_PRC_CI_AS NULL ,
	[Rpt_SQL] [text] COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Rpt_Params] [varchar] (2048) COLLATE Chinese_PRC_CI_AS NULL ,
	[Rpt_XML] [text] COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Role]    Script Date: 2006-4-18 18:14:39 ******/
CREATE TABLE [dbo].[xpGrid_Role] (
	[RoleId] [int] IDENTITY (1, 1) NOT NULL ,
	[RoleName] [varchar] (40) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[RoleDes] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_TableConstraint]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_TableConstraint] (
	[TableTypeID] [int] NOT NULL ,
	[ConstraintName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[ConstraintType] [varchar] (12) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[ConstraintDef] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_TableTemplate]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_TableTemplate] (
	[ColumnID] [int] IDENTITY (1, 1) NOT NULL ,
	[TableTypeID] [int] NOT NULL ,
	[ColName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[DataType] [varchar] (15) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Length] [int] NULL ,
	[XPrec] [int] NULL ,
	[XScale] [int] NULL ,
	[Nullable] [int] NULL ,
	[ColDefault] [varchar] (60) COLLATE Chinese_PRC_CI_AS NULL ,
	[DisplayLabel] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[DisplayOrder] [int] NOT NULL ,
	[DisplayWidth] [int] NULL ,
	[DisplayFormat] [varchar] (80) COLLATE Chinese_PRC_CI_AS NULL ,
	[EditFormat] [varchar] (80) COLLATE Chinese_PRC_CI_AS NULL ,
	[ColVarify] [varchar] (1024) COLLATE Chinese_PRC_CI_AS NULL ,
	[VarifyMsg] [varchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[ColVisible] [int] NULL ,
	[ColProperty] [int] NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_TableType]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_TableType] (
	[TableTypeID] [int] IDENTITY (1, 1) NOT NULL ,
	[TableTypeDes] [varchar] (40) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[TableVisible] [int] NULL ,
	[TablePreFix] [varchar] (6) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_Tables]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_Tables] (
	[TableName] [varchar] (64) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[TableTypeID] [int] NOT NULL ,
	[TableOrder] [int] NULL ,
	[TableLabel] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[TableVisible] [int] NULL ,
	[SelectCond] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[EditCond] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeleteCond] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_User]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_User] (
	[UserID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Password] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[deleted] [int] NOT NULL 
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[xpGrid_UsersInRoles]    Script Date: 2006-4-18 18:14:40 ******/
CREATE TABLE [dbo].[xpGrid_UsersInRoles] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[RoleId] [int] NOT NULL 
) ON [PRIMARY]
GO

/********************************************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_AttachmentsAddAttachment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_AttachmentsAddAttachment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_AttachmentsGetAttachment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_AttachmentsGetAttachment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_AttachmentsUpdateAttachment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_AttachmentsUpdateAttachment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ImagesAddImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_ImagesAddImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ImagesGetImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_ImagesGetImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ImagesSaveSizedImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_ImagesSaveSizedImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xpGrid_ImagesUpdateImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xpGrid_ImagesUpdateImage]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE xpGrid_AttachmentsAddAttachment
(
  @attachmentName NVarchar(250),
  @contentType NVarchar(50),
  @attachmentData image
)
AS
INSERT INTO xpGrid_Attachments
(
  Attachment_fileName,
  Attachment_contentType, 
  Attachment_attachmentData
)
VALUES 
(
  @attachmentName,  
  @contentType, 
  @attachmentData
)
Return @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE xpGrid_AttachmentsGetAttachment
(
  @AttachmentID int
)
AS
SELECT 
	Attachment_ContentType,
	Attachment_AttachmentData	
FROM 
	xpGrid_Attachments 
WHERE  Attachment_ID = @AttachmentID
RETURN 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

create PROCEDURE xpGrid_AttachmentsUpdateAttachment 
(
  @AttachmentID INT,
  @AttachmentName NVarchar(250),
  @contentType NVarchar(50),
  @AttachmentData Image
)
AS
UPDATE xpGrid_Attachments SET
  Attachment_FileName = @AttachmentName,
  Attachment_ContentType = @contentType,
  Attachment_AttachmentData = @AttachmentData
WHERE
  Attachment_ID = @AttachmentID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create PROCEDURE xpGrid_ImagesAddImage 
(
  @imageName NVarchar(250),
  @contentType NVarchar(50),
  @imageData image
)
AS
INSERT INTO xpGrid_Images
(
  Image_fileName,
  Image_contentType, 
  Image_imageData
)
VALUES 
(
  @imageName,  
  @contentType, 
  @ImageData
)
Return @@IDENTITY


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create PROCEDURE xpGrid_ImagesGetImage
(
  @imageID int,
  @width int,
  @height int,
  @isThumbnail bit
)
AS
-- If sized image, try to get it
IF (@width <> -1 OR @height <> -1)
BEGIN
	IF EXISTS
	(
	  SELECT 
		image_ID
	  FROM
		xpGrid_Images 
	  WHERE image_id = @imageID
		AND image_sizedImageWidth = @width 
		AND image_sizedImageHeight = @height
		AND image_sizedImageIsThumbnail = @isThumbnail
	)
	BEGIN
		-- Success! Return sized image
		SELECT
			image_sizedImageWidth width,
			image_sizedImageHeight height,
			image_sizedImageIsThumbnail isThumbnail,
			image_contentType,
			image_sizedImageData image_imageData
		FROM  
			xpGrid_Images (nolock)
		WHERE
			image_id = @imageID
	END
	ELSE
	BEGIN
		-- failure! Return normal image
		SELECT
			-1 width,
			-1 height,
			0 isThumbnail,
			image_contentType,
			image_ImageData
		FROM  
			xpGrid_Images 
		WHERE image_id = @imageID
 	END
END
-- Just select normal image
SELECT 
	-1 width,
	-1 height,
	0 isThumbnail,
	Image_ContentType,
	Image_ImageData	
FROM 
	xpGrid_Images 
WHERE  Image_ID = @imageID
RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create PROCEDURE xpGrid_ImagesSaveSizedImage 
(
  @imageID int,
  @sizedImageWidth int,
  @sizedImageHeight int,
  @sizedImageIsThumbnail bit,
  @sizedImageData Image
)
AS
UPDATE xpGrid_Images SET
  image_sizedImageHeight = @sizedImageHeight,
  image_sizedImageWidth = @sizedImageWidth,
  image_sizedImageIsThumbnail = @sizedImageIsThumbnail,
  image_sizedImageData = @sizedImageData
WHERE 
 image_id = @imageID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create PROCEDURE xpGrid_ImagesUpdateImage 
(
  @imageID INT,
  @imageName NVarchar(250),
  @contentType NVarchar(50),
  @imageData image
)
AS
UPDATE xpGrid_Images SET
  Image_FileName = @imageName,
  Image_ContentType = @contentType,
  Image_ImageData = @imageData,
  Image_SizedImageWidth = -1,
  Image_SizedImageHeight = -1,
  Image_SizedImageIsThumbnail = 0,
  Image_SizedImageData = null
WHERE
  Image_ID = @imageID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


/***********************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BM_AE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BM_AE]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BM_AX]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BM_AX]
GO

--CREATE TABLE [dbo].[BM_AE] (
--	[BM0000] [char] (2) COLLATE Chinese_PRC_CI_AS NOT NULL ,
--	[MC0000] [varchar] (28) COLLATE Chinese_PRC_CI_AS NOT NULL ,
--	[PARENTBM] [char] (2) COLLATE Chinese_PRC_CI_AS NULL 
--) ON [PRIMARY]
--GO

--CREATE TABLE [dbo].[BM_AX] (
--	[BM0000] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL ,
--	[MC0000] [varchar] (6) COLLATE Chinese_PRC_CI_AS NOT NULL ,
--	[PARENTBM] [char] (1) COLLATE Chinese_PRC_CI_AS NULL 
--) ON [PRIMARY]
--GO

ALTER TABLE [dbo].[xpGrid_Attachments] WITH NOCHECK ADD 
	CONSTRAINT [PK_xpGrid_Attachments] PRIMARY KEY  CLUSTERED 
	(
		[Attachment_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Datatypes] WITH NOCHECK ADD 
	CONSTRAINT [PK_xpGrid_Datatypes] PRIMARY KEY  CLUSTERED 
	(
		[TypeName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Functions] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_FuncFrame_PK] PRIMARY KEY  CLUSTERED 
	(
		[FuncCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Images] WITH NOCHECK ADD 
	CONSTRAINT [PK_xpGrid_Images] PRIMARY KEY  CLUSTERED 
	(
		[Image_id]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QueryConditionSets] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QueryConditionSets_PK] PRIMARY KEY  CLUSTERED 
	(
		[SetID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QueryProjectClass] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QuerySuiteClass_PK] PRIMARY KEY  CLUSTERED 
	(
		[ClassID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QuerySavers] WITH NOCHECK ADD 
	CONSTRAINT [PK_xpGrid_QuerySavers] PRIMARY KEY  CLUSTERED 
	(
		[SaverID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Role] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_Role_PK] PRIMARY KEY  CLUSTERED 
	(
		[RoleId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_TableType] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_TableType_PK] PRIMARY KEY  CLUSTERED 
	(
		[TableTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_User] WITH NOCHECK ADD 
	CONSTRAINT [A01_PK] PRIMARY KEY  CLUSTERED 
	(
		[UserID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_DefaultField] WITH NOCHECK ADD 
	CONSTRAINT [PK_xpGrid_DefaultField] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_FuncsInRoles] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_FunAssign_PK] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QueryProjects] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QueryProjects_PK] PRIMARY KEY  CLUSTERED 
	(
		[ProjectID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Reports] WITH NOCHECK ADD 
	CONSTRAINT [pk_xpGrid_Reports] PRIMARY KEY  CLUSTERED 
	(
		[Rpt_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_TableConstraint] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_TableConstraint_PK] PRIMARY KEY  CLUSTERED 
	(
		[ConstraintName],
		[TableTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_TableTemplate] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_TableTemplate_PK] PRIMARY KEY  CLUSTERED 
	(
		[ColumnID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Tables] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_Tables_PK] PRIMARY KEY  CLUSTERED 
	(
		[TableName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_UsersInRoles] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_UsersInRoles_PK] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Columns] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_Columns_PK] PRIMARY KEY  CLUSTERED 
	(
		[ColumnID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_ReportParams] WITH NOCHECK ADD 
	CONSTRAINT [pk_xpGrid_ReportParams] PRIMARY KEY  CLUSTERED 
	(
		[ParamID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_ColumnsInRoles] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_ColumnsInRoles_PK] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QueryConditionItems] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QueryConditionItems_PK] PRIMARY KEY  CLUSTERED 
	(
		[ItemID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QueryFields] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QueryFields_PK] PRIMARY KEY  CLUSTERED 
	(
		[FieldID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_QuerySorts] WITH NOCHECK ADD 
	CONSTRAINT [xpGrid_QuerySorts_PK] PRIMARY KEY  CLUSTERED 
	(
		[SortID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Images] ADD 
	CONSTRAINT [DF_xpGrid_Images_Image_SizedImageWidth] DEFAULT ((-1)) FOR [Image_SizedImageWidth],
	CONSTRAINT [DF_xpGrid_Images_Image_SizedImageHeight] DEFAULT ((-1)) FOR [Image_SizedImageHeight],
	CONSTRAINT [DF_xpGrid_Images_Image_SizedImageIsThumbnail] DEFAULT (1) FOR [Image_SizedImageIsThumbnail]
GO

ALTER TABLE [dbo].[xpGrid_QueryConditionSets] ADD 
	CONSTRAINT [DF__RYConditi__SetCa__68F2894D] DEFAULT ('''''') FOR [SetCaption]
GO

 CREATE  UNIQUE  INDEX [idx_Role_Name] ON [dbo].[xpGrid_Role]([RoleName]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[xpGrid_User] ADD 
	CONSTRAINT [DF_xpGrid_User_Password] DEFAULT (123) FOR [Password],
	CONSTRAINT [DF_A01_A0193] DEFAULT (0) FOR [deleted],
	CONSTRAINT [IX_xpGrid_User] UNIQUE  NONCLUSTERED 
	(
		[UserName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_DefaultField] ADD 
	CONSTRAINT [IX_xpGrid_DefaultField] UNIQUE  NONCLUSTERED 
	(
		[UserID],
		[PageInfo]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Reports] ADD 
	CONSTRAINT [IX_xpGrid_Reports] UNIQUE  NONCLUSTERED 
	(
		[Rpt_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_TableTemplate] ADD 
	CONSTRAINT [DF__xpGrid_Table__ColNu__286302EC] DEFAULT (1) FOR [Nullable],
	CONSTRAINT [DF__xpGrid_Table__ColVi__29572725] DEFAULT (1) FOR [ColVisible],
	CONSTRAINT [DF__xpGrid_Table__ColPr__2A4B4B5E] DEFAULT (2) FOR [ColProperty]
GO

 CREATE  UNIQUE  INDEX [TableTemplate_Index1] ON [dbo].[xpGrid_TableTemplate]([ColName], [TableTypeID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[xpGrid_Tables] ADD 
	CONSTRAINT [DF__xpGrid_Table__Table__20C1E124] DEFAULT (1) FOR [TableVisible]
GO

 CREATE  UNIQUE  INDEX [idx_xpGrid_Tables_Label] ON [dbo].[xpGrid_Tables]([TableLabel]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[xpGrid_UsersInRoles] ADD 
	CONSTRAINT [RoleAssign_Index2] UNIQUE  NONCLUSTERED 
	(
		[UserID],
		[RoleId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[xpGrid_Columns] ADD 
	CONSTRAINT [DF__xpGrid_Colum__ColNu__2D27B809] DEFAULT (1) FOR [Nullable],
	CONSTRAINT [DF__xpGrid_Colum__ColVi__2E1BDC42] DEFAULT (1) FOR [ColVisible],
	CONSTRAINT [DF__xpGrid_Colum__ColPr__2F10007B] DEFAULT (2) FOR [ColProperty]
GO

 CREATE  UNIQUE  INDEX [xpGrid_Columns_Idx1] ON [dbo].[xpGrid_Columns]([TableName], [ColName]) ON [PRIMARY]
GO

 CREATE  INDEX [xpGrid_Columns_Idx2] ON [dbo].[xpGrid_Columns]([TableName], [DisplayOrder]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[xpGrid_QueryConditionItems] ADD 
	CONSTRAINT [DF__RYConditi__IsPre__66161CA2] DEFAULT (0) FOR [IsPre]
GO

ALTER TABLE [dbo].[xpGrid_DefaultField] ADD 
	CONSTRAINT [FK_xpGrid_DefaultField_xpGrid_User] FOREIGN KEY 
	(
		[UserID]
	) REFERENCES [dbo].[xpGrid_User] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_FuncsInRoles] ADD 
	CONSTRAINT [xpGrid_FuncFrame_xpGrid_FunAssign_FK1] FOREIGN KEY 
	(
		[FuncCode]
	) REFERENCES [dbo].[xpGrid_Functions] (
		[FuncCode]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_Role_xpGrid_FunAssign_FK1] FOREIGN KEY 
	(
		[RoleId]
	) REFERENCES [dbo].[xpGrid_Role] (
		[RoleId]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_QueryProjects] ADD 
	CONSTRAINT [FK_xpGrid_QueryProjects_xpGrid_QueryConditionSets] FOREIGN KEY 
	(
		[CondID]
	) REFERENCES [dbo].[xpGrid_QueryConditionSets] (
		[SetID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_TableConstraint] ADD 
	CONSTRAINT [xpGrid_TableType_xpGrid_TableConstraint_FK1] FOREIGN KEY 
	(
		[TableTypeID]
	) REFERENCES [dbo].[xpGrid_TableType] (
		[TableTypeID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_TableTemplate] ADD 
	CONSTRAINT [xpGrid_TableType_xpGrid_TableTemplate_FK1] FOREIGN KEY 
	(
		[TableTypeID]
	) REFERENCES [dbo].[xpGrid_TableType] (
		[TableTypeID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_Tables] ADD 
	CONSTRAINT [FK_xpGrid_Tables_xpGrid_TableType] FOREIGN KEY 
	(
		[TableTypeID]
	) REFERENCES [dbo].[xpGrid_TableType] (
		[TableTypeID]
	) ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_UsersInRoles] ADD 
	CONSTRAINT [FK_xpGrid_UsersInRoles_xpGrid_User] FOREIGN KEY 
	(
		[UserID]
	) REFERENCES [dbo].[xpGrid_User] (
		[UserID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_Role_xpGrid_UsersInRoles_FK1] FOREIGN KEY 
	(
		[RoleId]
	) REFERENCES [dbo].[xpGrid_Role] (
		[RoleId]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_Columns] ADD 
	CONSTRAINT [FK_xpGrid_Columns_xpGrid_Tables] FOREIGN KEY 
	(
		[TableName]
	) REFERENCES [dbo].[xpGrid_Tables] (
		[TableName]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_ReportParams] ADD 
	CONSTRAINT [FK_xpGrid_ReportParams_xpGrid_Reports] FOREIGN KEY 
	(
		[Rpt_ID]
	) REFERENCES [dbo].[xpGrid_Reports] (
		[Rpt_ID]
	) ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_ColumnsInRoles] ADD 
	CONSTRAINT [xpGrid_Columns_xpGrid_ColumnsInRoles_FK1] FOREIGN KEY 
	(
		[ColumnID]
	) REFERENCES [dbo].[xpGrid_Columns] (
		[ColumnID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_Role_xpGrid_ColumnsInRoles_FK1] FOREIGN KEY 
	(
		[RoleId]
	) REFERENCES [dbo].[xpGrid_Role] (
		[RoleId]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_QueryConditionItems] ADD 
	CONSTRAINT [xpGrid_Columns_xpGrid_QueryConditionItems_FK1] FOREIGN KEY 
	(
		[ColumnID]
	) REFERENCES [dbo].[xpGrid_Columns] (
		[ColumnID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_QueryConditionSets_Item_FK1] FOREIGN KEY 
	(
		[SetID]
	) REFERENCES [dbo].[xpGrid_QueryConditionSets] (
		[SetID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_QueryFields] ADD 
	CONSTRAINT [xpGrid_Columns_xpGrid_QueryFields_FK1] FOREIGN KEY 
	(
		[ColumnID]
	) REFERENCES [dbo].[xpGrid_Columns] (
		[ColumnID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_QueryProjects_xpGrid_ueryFields_FK1] FOREIGN KEY 
	(
		[SuiteID]
	) REFERENCES [dbo].[xpGrid_QueryProjects] (
		[ProjectID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[xpGrid_QuerySorts] ADD 
	CONSTRAINT [xpGrid_Columns_xpGrid_QuerySorts_FK1] FOREIGN KEY 
	(
		[ColumnID]
	) REFERENCES [dbo].[xpGrid_Columns] (
		[ColumnID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [xpGrid_QueryProjects_xpGrid_QuerySorts_FK1] FOREIGN KEY 
	(
		[SuiteID]
	) REFERENCES [dbo].[xpGrid_QueryProjects] (
		[ProjectID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE dbo.xpGrid_QuerySavers ADD CONSTRAINT
	FK_xpGrid_QuerySavers_xpGrid_User FOREIGN KEY
	(
	UserID
	) REFERENCES dbo.xpGrid_User
	(
	UserID
	) ON UPDATE CASCADE
	 ON DELETE CASCADE
	
GO
ALTER TABLE dbo.xpGrid_QueryProjects ADD CONSTRAINT
	FK_xpGrid_QueryProjects_xpGrid_QueryProjectClass FOREIGN KEY
	(
	ClassID
	) REFERENCES dbo.xpGrid_QueryProjectClass
	(
	ClassID
	) ON UPDATE CASCADE
	 ON DELETE CASCADE
	
GO





/*******************************************************************************************/
-- INSERT [BM_AX] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '0' , '未知' , ' ' )
-- INSERT [BM_AX] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '1' , '男' , ' ' )
-- INSERT [BM_AX] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '2' , '女' , ' ' )
-- INSERT [BM_AX] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '9' , '其它' , ' ' )

-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '01' , '汉族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '02' , '蒙古族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '03' , '回族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '04' , '藏族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '05' , '维吾尔族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '06' , '苗族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '07' , '彝族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '08' , '壮族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '09' , '布依族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '10' , '朝鲜族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '11' , '满族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '12' , '侗族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '13' , '瑶族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '14' , '白族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '15' , '土家族　' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '16' , '哈尼族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '17' , '哈萨克族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '18' , '傣族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '19' , '黎族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '20' , '傈僳族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '21' , '佤族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '22' , '畲族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '23' , '高山族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '24' , '拉祜族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '25' , '水族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '26' , '东乡族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '27' , '纳西族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '28' , '景颇族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '29' , '柯尔克孜族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '30' , '土族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '31' , '达斡尔族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '32' , '仫佬族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '33' , '羌族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '34' , '布朗族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '35' , '撒拉族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '36' , '毛南族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '37' , '仡佬族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '38' , '锡伯族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '39' , '阿昌族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '40' , '普米族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '41' , '塔吉克族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '42' , '怒族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '43' , '乌孜别克族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '44' , '俄罗斯族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '45' , '鄂温克族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '46' , '德昂族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '47' , '保安族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '48' , '裕固族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '49' , '京族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '50' , '塔塔尔族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '51' , '独龙族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '52' , '鄂伦春族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '53' , '赫哲族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '54' , '门巴族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '55' , '珞巴族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '56' , '基诺族' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '97' , '其他' , '  ' )
-- INSERT [BM_AE] ( [BM0000] , [MC0000] , [PARENTBM] ) VALUES ( '98' , '外国血统中国籍人士' , '  ' )

 SET IDENTITY_INSERT [xpGrid_Role] ON

 INSERT [xpGrid_Role] ( [RoleId] , [RoleName] , [RoleDes] ) VALUES ( 1 , '系统管理员' , '' )
 INSERT [xpGrid_Role] ( [RoleId] , [RoleName] , [RoleDes] ) VALUES ( 2 , '普通用户' , '' )

 SET IDENTITY_INSERT [xpGrid_Role] OFF




 SET IDENTITY_INSERT [xpGrid_TableType] ON

 INSERT [xpGrid_TableType] ( [TableTypeID] , [TableTypeDes] , [TableVisible] ) VALUES ( 1 , '系统表' , 0 )
 --INSERT [xpGrid_TableType] ( [TableTypeID] , [TableTypeDes] , [TableVisible] , [TablePreFix] ) VALUES ( 2 , '编码表' , 0 , 'BM_' )
 INSERT [xpGrid_TableType] ( [TableTypeID] , [TableTypeDes] , [TableVisible] ) VALUES ( 3 , '业务表' , 0 )

 SET IDENTITY_INSERT [xpGrid_TableType] OFF




-- INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'BM_AE' , 2 , 4 , '民族' , 2 )
-- INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'BM_AX' , 2 , 22 , '性别' , 2 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_Role' , 1 , 'xpGrid_Role' , 1 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_UsersInRoles' , 1 , 'xpGrid_UsersInRoles' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_COLUMNSInRoles' , 1 , 'xpGrid_COLUMNSInRoles' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_COLUMNS' , 1 , 'xpGrid_COLUMNS' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_DATATYPES' , 1 , 'xpGrid_DATATYPES' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_FuncsInRoles' , 1 , 'xpGrid_FuncsInRoles' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_FUNCTIONS' , 1 , 'xpGrid_Functions' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_TABLECONSTRAINT' , 1 , 'xpGrid_TABLECONSTRAINT' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_TABLES' , 1 , 'xpGrid_TABLES' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_TABLETEMPLATE' , 1 , 'xpGrid_TABLETEMPLATE' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_TABLETYPE' , 1 , 'xpGrid_TABLETYPE' , 0 )
 INSERT [xpGrid_Tables] ( [TableName] , [TableTypeID] , [TableOrder] , [TableLabel] , [TableVisible] ) VALUES ( 'xpGrid_User' , 3 , 1 , '人员基本信息' , 2 )



 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'BIGINT' , 'BIGINT' , 127 , 8 , 19 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'BINARY' , 'BINARY' , 173 , 256 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'BIT' , 'BIT' , 104 , 1 , 1 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'CHAR' , 'CHAR' , 175 , 10 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'DATETIME' , 'DATETIME' , 61 , 8 , 23 , 3 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'DECIMAL' , 'DECIMAL' , 106 , 17 , 18 , 2 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'FLOAT' , 'FLOAT' , 62 , 8 , 53 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'IMAGE' , 'IMAGE' , 34 , 16 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'INT' , 'INT' , 56 , 4 , 10 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'MONEY' , 'MONEY' , 60 , 8 , 19 , 4 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'NCHAR' , 'NCHAR' , 239 , 10 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'NTEXT' , 'NTEXT' , 99 , 16 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'NUMERIC' , 'NUMERIC' , 108 , 17 , 38 , 38 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'NVARCHAR' , 'NVARCHAR' , 231 , 50 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'REAL' , 'REAL' , 59 , 4 , 24 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'SMALLDATETIME' , 'SMALLDATETIME' , 58 , 4 , 16 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'SMALLINT' , 'SMALLINT' , 52 , 2 , 5 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'SMALLMONEY' , 'SMALLMONEY' , 122 , 4 , 10 , 4 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'SQL_VARIANT' , 'SQL_VARIANT' , 98 , 256 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'SYSNAME' , 'SYSNAME' , 231 , 256 , 0 , 0 , 0 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'TEXT' , 'TEXT' , 35 , 16 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'TIMESTAMP' , 'TIMESTAMP' , 189 , 8 , 0 , 0 , 0 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'TINYINT' , 'TINYINT' , 48 , 1 , 3 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'UNIQUEIDENTIFIER' , 'UNIQUEIDENTIFIER' , 36 , 16 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'VARBINARY' , 'VARBINARY' , 165 , 256 , 0 , 0 , 1 )
 INSERT [xpGrid_Datatypes] ( [TypeName] , [TypeLabel] , [XType] , [Length] , [XPrec] , [XScale] , [Allownulls] ) VALUES ( 'VARCHAR' , 'VARCHAR' , 167 , 50 , 0 , 0 , 1 )




 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_Role' , 'RoleID' , 'INT IDENTITY' , 4 , 0 , 0 , 'RoleID' , 0 , 4 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_Role' , 'RoleNAME' , 'VARCHAR' , 40 , 0 , 0 , 'RoleNAME' , 0 , 40 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_Role' , 'RoleDES' , 'VARCHAR' , 255 , 0 , 1 , 'RoleDES' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_UsersInRoles' , 'ID' , 'INT IDENTITY' , 4 , 0 , 0 , 'ID' , 0 , 4 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_UsersInRoles' , 'USERID' , 'INT' , 4 , 0 , 0 , 'USERID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_UsersInRoles' , 'RoleID' , 'INT' , 4 , 0 , 0 , 'RoleID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_ColumnsInRoles' , 'ID' , 'INT' , 4 , 0 , 0 , 'ID' , 0 , 4 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_ColumnsInRoles' , 'RoleID' , 'INT IDENTITY' , 4 , 0 , 1 , 'RoleID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_ColumnsInRoles' , 'COLUMNID' , 'INT' , 4 , 0 , 1 , 'COLUMNID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_ColumnsInRoles' , 'ALLOWEDIT' , 'INT' , 4 , 0 , 1 , 'ALLOWEDIT' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLUMNID' , 'INT' , 4 , 0 , 0 , 'COLUMNID' , 0 , 4 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'TABLENAME' , 'VARCHAR' , 30 , 0 , 0 , 'TABLENAME' , 0 , 30 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLNAME' , 'VARCHAR' , 20 , 0 , 0 , 'COLNAME' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'DATATYPE' , 'VARCHAR' , 15 , 0 , 0 , 'COLTYPE' , 0 , 15 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'LENGTH' , 'INT' , 4 , 0 , 1 , 'COLWIDTH' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'XPREC' , 'INT' , 4 , 0 , 1 , 'COLPRECISION' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLDEFAULT' , 'VARCHAR' , 60 , 0 , 1 , 'COLDEFAULT' , 0 , 60 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'DISPLAYLABEL' , 'VARCHAR' , 40 , 0 , 1 , 'DISPLAYLABEL' , 0 , 40 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'DISPLAYWIDTH' , 'INT' , 4 , 0 , 1 , 'DISPLAYWIDTH' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'DISPLAYFORMAT' , 'VARCHAR' , 80 , 0 , 1 , 'DISPLAYFORMAT' , 0 , 80 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'EDITFORMAT' , 'VARCHAR' , 255 , 0 , 1 , 'EDITFORMAT' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLVARIFY' , 'VARCHAR' , 1024 , 0 , 1 , 'COLVARIFY' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'VARIFYMSG' , 'VARCHAR' , 255 , 0 , 1 , 'VARIFYMSG' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLVISIBLE' , 'INT' , 4 , 0 , 1 , 'COLVISIBLE' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_COLUMNS' , 'COLPROPERTY' , 'INT' , 4 , 0 , 1 , 'COLPROPERTY' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FuncsInRoles' , 'ID' , 'INT' , 4 , 0 , 0 , 'ID' , 0 , 4 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FuncsInRoles' , 'RoleID' , 'INT' , 4 , 0 , 1 , 'RoleID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FuncsInRoles' , 'FUNCCODE' , 'VARCHAR' , 30 , 0 , 1 , 'FUNCCODE' , 0 , 30 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FUNCTIONS' , 'FUNCCODE' , 'VARCHAR' , 30 , 0 , 0 , 'FUNCCODE' , 0 , 0 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FUNCTIONS' , 'FUNCNAME' , 'VARCHAR' , 100 , 0 , 1 , 'FUNCNAME' , 0 , 0, 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FUNCTIONS' , 'FUNCURL' , 'VARCHAR' , 200 , 0 , 1 , 'FUNC_URL' , 0 , 0 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_FUNCTIONS' , 'FUNCPARENT' , 'VARCHAR' , 10 , 0 , 1 , 'FUNCPARENT' , 0 , 0 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty],[EditFormat] ) VALUES ( 'xpGrid_FUNCTIONS' , 'ENABLE' , 'BIT' , 10 , 0 , 1 , 'ENABLE' , 0 , 10 , 2 , 2, 'CHECK(正常|1|0)')
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLECONSTRAINT' , 'TABLETYPEID' , 'INT' , 4 , 0 , 0 , 'TABLETYPEID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLECONSTRAINT' , 'CONSTRAINTNAME' , 'VARCHAR' , 20 , 0 , 0 , 'CONSTRAINTNAME' , 0 , 20 , 2, 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLECONSTRAINT' , 'CONSTRAINTTYPE' , 'VARCHAR' , 12 , 0 , 0 , 'CONSTRAINTTYPE' , 0 , 12 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLECONSTRAINT' , 'CONSTRAINTDEF' , 'VARCHAR' , 255 , 0 , 0 , 'CONSTRAINTDEF' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLES' , 'TABLEVISIBLE' , 'INT' , 4 , 0 , 1 , 'TABLEVISIBLE' , 0 , 4 , 1 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLES' , 'TABLENAME' , 'VARCHAR' , 30 , 0 , 0 , '' , '表名' , 0 , 30 , '' , '' , '' , '' , 3 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLES' , 'TABLETYPEID' , 'INT' , 4 , 0 , 0 , 'TABLETYPEID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLES' , 'TABLEORDER' , 'INT' , 4 , 0 , 1 , 'TABLEORDER' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLES' , 'TABLELABEL' , 'VARCHAR' , 40 , 0 , 1 , '' , '中文名' , 0 , 40 , '' , '' , '' , '' , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'TABLETYPEID' , 'INT' , 4 , 0 , 0 , 'TABLETYPEID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLNAME' , 'VARCHAR' , 20 , 0 , 0 , 'COLNAME' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'DATATYPE' , 'VARCHAR' , 15 , 0 , 0 , 'COLTYPE' , 0 , 15 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'LENGTH' , 'INT' , 4 , 0 , 1 , 'COLWIDTH' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'XPREC' , 'INT' , 4 , 0 , 1 , 'COLPRECISION' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLDEFAULT' , 'VARCHAR' , 60 , 0 , 1 , 'COLDEFAULT' , 0 , 60 , 2, 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'DISPLAYLABEL' , 'VARCHAR' , 40 , 0 , 1 , 'DISPLAYLABEL' , 0 , 40 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'DISPLAYWIDTH' , 'INT' , 4 , 0 , 1 , 'DISPLAYWIDTH' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'DISPLAYFORMAT' , 'VARCHAR' , 80 , 0 , 1 , 'DISPLAYFORMAT' , 0 , 80 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'EDITFORMAT' , 'VARCHAR' , 80 , 0 , 1 , 'EDITFORMAT' , 0 , 80 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLVARIFY' , 'VARCHAR' , 1024 , 0 , 1 , 'COLVARIFY' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'VARIFYMSG' , 'VARCHAR' , 255 , 0 , 1 , 'VARIFYMSG' , 0 , 255 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLVISIBLE' , 'INT' , 4 , 0 , 1 , 'COLVISIBLE' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLPROPERTY' , 'INT' , 4 , 0 , 1 , 'COLPROPERTY' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETEMPLATE' , 'COLUMNID' , 'INT' , 4 , 0 , 0 , 'COLUMNID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETYPE' , 'TABLETYPEID' , 'INT' , 4 , 0 , 0 , 'TABLETYPEID' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETYPE' , 'TABLETYPEDES' , 'VARCHAR' , 40 , 0 , 0 , 'TABLETYPEDES' , 0 , 40 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETYPE' , 'TABLEVISIBLE' , 'INT' , 4 , 0 , 1 , 'TABLEVISIBLE' , 0 , 4 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_TABLETYPE' , 'TABLEPREFIX' , 'VARCHAR' , 6 , 0 , 1 , 'TABLEPREFIX' , 0 , 6 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'TYPENAME' , 'VARCHAR' , 20 , 0 , 1 , 'TYPENAME' , 0 , 20 , 2 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'TYPELABEL' , 'VARCHAR' , 20 , 0 , 1 , 'TYPELABEL' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'XTYPE' , 'SMALLINT' , 2 , 0 , 1 , 'XTYPE' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'LENGTH' , 'SMALLINT' , 2 , 0 , 1 , 'LENGTH' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'XPREC' , 'TINYINT' , 2 , 0 , 1 , 'XPREC' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'XSCALE' , 'TINYINT' , 2 , 0 , 1 , 'XSCALE' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'XPGRID_DATATYPES' , 'ALLOWNULLS' , 'BIT' , 2 , 0 , 1 , 'ALLOWNULLS' , 0 , 20 , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'USERID' , 'INT IDENTITY' , 8 , 0 , 0 , '' , '用户编号' , 0 , 0 , '' , '' , '' , '' , 3 , 1 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'USERNAME' , 'VARCHAR' , 20 , 0 , 0 , '' , '用户名称' , 0 , 100 , '' , '' , '' , '' , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'PASSWORD' , 'VARCHAR' , 20 , 0 , 1 , '' , '用户密码' , 0 , 80 , '*' , 'PASSWORD' , '' , '' , 2 , 2 )
 INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'DELETED' , 'INT' , 4 , 0 , 0 , '' , '删除标志' , 0 , 80 , '' , 'CHECK(删除|1|0)' , '' , '' , 2 , 2 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'DELETED' , 'INT' , 4 , 0 , 0 , '' , '删除标志' , 0 , 80 , '' , '' , '' , '' , 2 , 2 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'Sex' , 'VARCHAR' , 1 , 0 , 1 , '' , '性别' , 4 , 30 , '' , 'CODE(BM_AX|0)' , '' , '' , 2 , 3 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [ColDefault] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [DisplayFormat] , [EditFormat] , [ColVarify] , [VarifyMsg] , [ColVisible] , [ColProperty] ) VALUES ( 'xpGrid_User' , 'Sex' , 'VARCHAR' , 1 , 0 , 1 , '' , '性别' , 4 , 30 , '' , '' , '' , '' , 2 , 3 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AE' , 'BM0000' , 'CHAR' , 2 , 0 , 0 , '代码' , 0 , 0 , 2 , 1 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AE' , 'MC0000' , 'VARCHAR' , 28 , 0 , 0 , '名称' , 0 , 0 , 2 , 2 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AE' , 'PARENTBM' , 'CHAR' , 2 , 0 , 1 , '父代码' , 0 , 0 , 2 , 2 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AX' , 'BM0000' , 'CHAR' , 1 , 0 , 0 , '代码' , 0 , 0 , 2 , 1 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AX' , 'MC0000' , 'VARCHAR' , 6 , 0 , 0 , '名称' , 0 , 0 , 2 , 2 )
-- INSERT [xpGrid_Columns] ( [TableName] , [ColName] , [DataType] , [Length] , [XPrec] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 'BM_AX' , 'PARENTBM' , 'CHAR' , 1 , 0 , 1 , '父代码' , 0 , 0 , 2 , 2 )


 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '0099' , '数据重构' , '00', 'xpGrid/Images/home.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '009901' , '数据重构' , '' , '0099' , 'xpGrid/Images/MenuBar.jpg', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00990101' , '数据重构' , 'xpGrid/admin/EditDbStruct/default.aspx' , '009901' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00990102' , '表类别设置' , 'xpGrid/admin/EditDbStruct/TableTypeEdit.aspx' , '009901' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00990109' , '数据字典更新' , 'xpGrid/admin/EditDbStruct/SyncSysColumn.aspx' , '009901' , 'xpGrid/Images/cp.gif', 1)
-- INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00990103' , 'xpGrid初始化' , 'xpGrid/admin/EditDbStruct/xpGridInit.aspx' , '009901' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '0091' , '权限管理' , '00', 'xpGrid/Images/home.gif', 1 )
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '009101' , '权限管理' , '0091', 'xpGrid/Images/MenuBar.jpg', 1 )
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00910101' , '角色管理' , 'xpGrid/admin/EditRoles/default.aspx' , '009101' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00910102' , '用户授权' , 'xpGrid/admin/EditRoles/EditUser.aspx' , '009101' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00910103' , '密码修改' , 'xpGrid/admin/EditRoles/ChangePwd.aspx' , '009101' , 'xpGrid/Images/cp.gif', 1)
 INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00910104' , '系统功能维护' , 'xpGrid/admin/EditRoles/FuncEdit.aspx' , '009101' , 'xpGrid/Images/cp.gif', 1)
-- INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '0092' , '代码维护' , '00' , 'xpGrid/Images/home.gif', 1)
-- INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '009201' , '代码维护' , '0092' , 'xpGrid/Images/MenuBar.jpg', 1)
-- INSERT [xpGrid_Functions] ( [FuncCode] , [FuncName] , [FuncUrl] , [FuncParent], [FuncImg], [Enable] ) VALUES ( '00920101' , '代码表维护' , 'xpGrid/admin/code/default.aspx' , '0092' , 'xpGrid/Images/cp.gif', 1)


-- SET IDENTITY_INSERT [xpGrid_TableTemplate] ON

-- INSERT [xpGrid_TableTemplate] ( [ColumnID] , [TableTypeID] , [ColName] , [DataType] , [Length] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 1 , 2 , 'BM0000' , 'CHAR' , 2 , 0 , '编码' , 1 , 0 , 2 , 1 )
-- INSERT [xpGrid_TableTemplate] ( [ColumnID] , [TableTypeID] , [ColName] , [DataType] , [Length] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 2 , 2 , 'MC0000' , 'VARCHAR' , 40 , 0 , '名称' , 2 , 0 , 2 , 2 )
-- INSERT [xpGrid_TableTemplate] ( [ColumnID] , [TableTypeID] , [ColName] , [DataType] , [Length] , [Nullable] , [DisplayLabel] , [DisplayOrder] , [DisplayWidth] , [ColVisible] , [ColProperty] ) VALUES ( 3 , 2 , 'PARENTBM' , 'CHAR' , 2 , 1 , '父编码' , 3 , 0 , 2 , 2 )

-- SET IDENTITY_INSERT [xpGrid_TableTemplate] OFF



 SET IDENTITY_INSERT [xpGrid_User] ON

 INSERT [xpGrid_User] ( [UserID] , [UserName] , [Password] , [deleted] ) VALUES ( 1 , 'Administrator' , '111' , 0 )


 SET IDENTITY_INSERT [xpGrid_User] OFF

 INSERT [xpGrid_UsersInRoles] ( [UserID] , [RoleId] ) VALUES ( 1 , 1 )


GO

select TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty into #xpGrid_Columns from xpGrid_Columns where 1=2
insert into #xpGrid_Columns(TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty)
SELECT o.name AS TableName, c.name AS ColumnName, UPPER(t.name) AS DatatypeName, c.length, c.xprec, c.xscale, c.isnullable AS Nullable, 
      c.cdefault AS ColDefault, c.name AS DisplayLabel, 100 AS DisplayOrder, 0 AS DisplayWidth, '' AS DisplayFormat, '' AS EditFormat, 
      '' AS ColVarify, '' AS VarifyMsg, 2 AS ColVisible, 
case when (select COLUMN_NAME = convert(sysname, c.name) 
	from sysindexes i where o.id = c.id
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
         WHERE xtype = 'u' AND not exists(
		select 1 from xpGrid_Columns where xpGrid_Columns.TableName = o.name and xpGrid_Columns.ColName = c.name)))
 AND (UPPER(t.name) <> 'SYSNAME') and o.name <> 'dtproperties' and o.name like 'xpgrid_%'

insert into xpGrid_Tables(TableName, TableTypeID, TableOrder, TableLabel, TableVisible)
select name, case when [name] like 'xpgrid_%' then 1 else 3 end, 1, name, 2 from sysobjects where xtype = 'u' and name not in(select tablename from xpGrid_Tables) and sysobjects.name <> 'dtproperties' and name like 'xpgrid_%'

insert into xpGrid_Columns(TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty)
select TableName, ColName, DataType, Length, XPrec, XScale, Nullable, ColDefault, DisplayLabel, DisplayOrder, DisplayWidth, DisplayFormat, EditFormat, ColVarify, VarifyMsg, ColVisible, ColProperty from #xpGrid_Columns where datatype <> 'SYSNAME'
drop table #xpGrid_Columns

GO

update xpGrid_Columns set DisplayWidth = 0 where TableName like 'xpGrid_%'
GO


/*2006年6月13日罗显华改，加更改后的xpGrid显示出错信息的提示表*/
CREATE TABLE [xpGrid_ConstraintMessages] (
[ConstraintName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
[ErrorMessage] [varchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
CONSTRAINT [PK_xpGrid_ConstraintMessages] PRIMARY KEY  CLUSTERED 
(
[ConstraintName]
)  ON [PRIMARY] 
) ON [PRIMARY]
GO

/*以下代码用错误，无法真正的进行转换*/
update xpgrid_columns set editformat =  
'LOOK(select ' + substring(editformat, charindex('|', editformat) + 1, 
charindex('|', editformat, charindex('|', editformat) + 1) - charindex('|', 
editformat) - 1) + ',' +
substring(editformat, charindex('|', editformat, charindex('|', editformat) 
+ 1) + 1, charindex('|', editformat, charindex('|', editformat, 
charindex('|', editformat) + 1) + 1) - charindex('|', editformat, 
charindex('|', editformat) + 1) - 1) +
' from ' + substring(editformat,6,charindex('|', editformat) - 6) + ' order 
by ' + 
substring(editformat, charindex('|', editformat, charindex('|', editformat, 
charindex('|', editformat, charindex('|', editformat) + 1) + 1) + 1) + 1, 
len(editformat) - charindex('|', editformat, charindex('|', editformat, 
charindex('|', editformat, charindex('|', editformat) + 1) + 1) + 1) - 1)
+ ')COND()INPUTFIELD()'
where editformat like 'look(%'
Go