/*
Navicat SQL Server Data Transfer

Source Server         : 192.168.0.1
Source Server Version : 90000
Source Host           : 192.168.0.1:1433
Source Database       : ResumeInfo
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 90000
File Encoding         : 65001

Date: 2015-12-08 12:48:33
*/


-- ----------------------------
-- Table structure for BaseInfo
-- ----------------------------
DROP TABLE [dbo].[BaseInfo]
GO
CREATE TABLE [dbo].[BaseInfo] (
[UserID] int NOT NULL IDENTITY(1,1) ,
[PName] varchar(50) NULL ,
[PID] varchar(50) NULL ,
[Sex] int NULL ,
[ypzly] int NULL ,
[csrq] datetime NULL ,
[zzmm] int NULL ,
[jg] varchar(50) NULL ,
[csd] varchar(50) NULL ,
[hkszd] varchar(50) NULL ,
[mz] varchar(50) NULL ,
[hyzk] int NULL ,
[jkzk] varchar(50) NULL ,
[grtc] varchar(50) NULL ,
[sj] varchar(50) NULL ,
[gddh] varchar(50) NULL ,
[lxdz] varchar(50) NULL ,
[email] varchar(50) NULL ,
[ypbm] int NULL ,
[ypgw] int NULL ,
[qwxc] int NULL ,
[dywy] int NULL ,
[dewy] int NULL ,
[jsj] int NULL ,
[zc] int NULL ,
[jypx] varchar(200) NULL ,
[xsky] varchar(200) NULL ,
[stqk] varchar(200) NULL ,
[jcqk] varchar(200) NULL ,
[CreateTime] datetime NULL ,
[ModifyTime] datetime NULL ,
[zfflag] bit NULL ,
[sg] varchar(50) NULL ,
[tz] varchar(50) NULL ,
[pwd] varchar(50) NULL ,
[zt] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[BaseInfo]', RESEED, 42561)
GO

-- ----------------------------
-- Table structure for enuGzsxlb
-- ----------------------------
DROP TABLE [dbo].[enuGzsxlb]
GO
CREATE TABLE [dbo].[enuGzsxlb] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuGzsxlb]', RESEED, 2)
GO

-- ----------------------------
-- Table structure for enuHyzk
-- ----------------------------
DROP TABLE [dbo].[enuHyzk]
GO
CREATE TABLE [dbo].[enuHyzk] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuHyzk]', RESEED, 3)
GO

-- ----------------------------
-- Table structure for enuJsj
-- ----------------------------
DROP TABLE [dbo].[enuJsj]
GO
CREATE TABLE [dbo].[enuJsj] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuJsj]', RESEED, 8)
GO

-- ----------------------------
-- Table structure for enuJyjd
-- ----------------------------
DROP TABLE [dbo].[enuJyjd]
GO
CREATE TABLE [dbo].[enuJyjd] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuJyjd]', RESEED, 5)
GO

-- ----------------------------
-- Table structure for enuLaiy
-- ----------------------------
DROP TABLE [dbo].[enuLaiy]
GO
CREATE TABLE [dbo].[enuLaiy] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(50) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuLaiy]', RESEED, 4)
GO

-- ----------------------------
-- Table structure for enuQwyx
-- ----------------------------
DROP TABLE [dbo].[enuQwyx]
GO
CREATE TABLE [dbo].[enuQwyx] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuQwyx]', RESEED, 5)
GO

-- ----------------------------
-- Table structure for enuSex
-- ----------------------------
DROP TABLE [dbo].[enuSex]
GO
CREATE TABLE [dbo].[enuSex] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuSex]', RESEED, 2)
GO

-- ----------------------------
-- Table structure for enuWjlx
-- ----------------------------
DROP TABLE [dbo].[enuWjlx]
GO
CREATE TABLE [dbo].[enuWjlx] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuWjlx]', RESEED, 11)
GO

-- ----------------------------
-- Table structure for enuWy
-- ----------------------------
DROP TABLE [dbo].[enuWy]
GO
CREATE TABLE [dbo].[enuWy] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuWy]', RESEED, 12)
GO

-- ----------------------------
-- Table structure for enuYpbm
-- ----------------------------
DROP TABLE [dbo].[enuYpbm]
GO
CREATE TABLE [dbo].[enuYpbm] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuYpbm]', RESEED, 39)
GO

-- ----------------------------
-- Table structure for enuYpgw
-- ----------------------------
DROP TABLE [dbo].[enuYpgw]
GO
CREATE TABLE [dbo].[enuYpgw] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuYpgw]', RESEED, 28)
GO

-- ----------------------------
-- Table structure for enuZc
-- ----------------------------
DROP TABLE [dbo].[enuZc]
GO
CREATE TABLE [dbo].[enuZc] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuZc]', RESEED, 22)
GO

-- ----------------------------
-- Table structure for enuZg
-- ----------------------------
DROP TABLE [dbo].[enuZg]
GO
CREATE TABLE [dbo].[enuZg] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuZg]', RESEED, 38)
GO

-- ----------------------------
-- Table structure for enuZt
-- ----------------------------
DROP TABLE [dbo].[enuZt]
GO
CREATE TABLE [dbo].[enuZt] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuZt]', RESEED, 4)
GO

-- ----------------------------
-- Table structure for enuZy
-- ----------------------------
DROP TABLE [dbo].[enuZy]
GO
CREATE TABLE [dbo].[enuZy] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuZy]', RESEED, 51)
GO

-- ----------------------------
-- Table structure for enuZzmm
-- ----------------------------
DROP TABLE [dbo].[enuZzmm]
GO
CREATE TABLE [dbo].[enuZzmm] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[Label] varchar(50) NULL ,
[Code] varchar(30) NULL ,
[DisOrder] int NULL ,
[IsShow] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[enuZzmm]', RESEED, 15)
GO

-- ----------------------------
-- Table structure for FileInfo
-- ----------------------------
DROP TABLE [dbo].[FileInfo]
GO
CREATE TABLE [dbo].[FileInfo] (
[FileID] int NOT NULL IDENTITY(1,1) ,
[UserID] int NOT NULL ,
[FName] varchar(50) NULL ,
[FLength] bigint NULL ,
[wjlx] int NULL ,
[fjsm] varchar(100) NULL ,
[UpTime] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[FileInfo]', RESEED, 92257)
GO

-- ----------------------------
-- Table structure for Gongzsx
-- ----------------------------
DROP TABLE [dbo].[Gongzsx]
GO
CREATE TABLE [dbo].[Gongzsx] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[UserID] int NOT NULL ,
[kssj] datetime NULL ,
[jssj] datetime NULL ,
[dw] varchar(50) NULL ,
[cszy] int NULL ,
[bmjzw] varchar(50) NULL ,
[zmr] varchar(10) NULL ,
[zmrlxdh] varchar(20) NULL ,
[sxnr] varchar(250) NULL ,
[gzsxlb] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Gongzsx]', RESEED, 98539)
GO

-- ----------------------------
-- Table structure for Jiaoybj
-- ----------------------------
DROP TABLE [dbo].[Jiaoybj]
GO
CREATE TABLE [dbo].[Jiaoybj] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[UserID] int NOT NULL ,
[kssj] datetime NULL ,
[jssj] datetime NULL ,
[byyx] varchar(50) NULL ,
[sxzy] int NULL ,
[bysj] datetime NULL ,
[ds] varchar(20) NULL ,
[jyjd] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Jiaoybj]', RESEED, 68175)
GO

-- ----------------------------
-- Table structure for Jiatshgx
-- ----------------------------
DROP TABLE [dbo].[Jiatshgx]
GO
CREATE TABLE [dbo].[Jiatshgx] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[UserID] int NOT NULL ,
[cw] varchar(20) NULL ,
[xm] varchar(20) NULL ,
[nl] int NULL ,
[zzmm] int NULL ,
[gzdw] varchar(50) NULL ,
[bmzw] varchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Jiatshgx]', RESEED, 43959)
GO

-- ----------------------------
-- Table structure for MenuItem
-- ----------------------------
DROP TABLE [dbo].[MenuItem]
GO
CREATE TABLE [dbo].[MenuItem] (
[MenuItemID] int NOT NULL IDENTITY(1,1) ,
[TopMenuID] int NOT NULL ,
[Name] varchar(50) NULL ,
[Icon] varchar(50) NULL ,
[URLPath] varchar(200) NULL ,
[DisplayOrder] int NULL ,
[Flag] bit NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[MenuItem]', RESEED, 13)
GO

-- ----------------------------
-- Table structure for TopMenu
-- ----------------------------
DROP TABLE [dbo].[TopMenu]
GO
CREATE TABLE [dbo].[TopMenu] (
[TopMenuID] int NOT NULL IDENTITY(1,1) ,
[Name] varchar(50) NULL ,
[DisplayOrder] int NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[TopMenu]', RESEED, 3)
GO

-- ----------------------------
-- Table structure for zhiwei
-- ----------------------------
DROP TABLE [dbo].[zhiwei]
GO
CREATE TABLE [dbo].[zhiwei] (
[pkid] int NOT NULL IDENTITY(1,1) ,
[name] varchar(50) NULL ,
[code] varchar(50) NULL ,
[sl] varchar(50) NULL ,
[ms] varchar(2000) NULL ,
[zy] varchar(50) NULL ,
[bm] varchar(50) NULL ,
[xz] varchar(50) NULL ,
[ltime] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[zhiwei]', RESEED, 2)
GO

-- ----------------------------
-- Table structure for Zhiyzg
-- ----------------------------
DROP TABLE [dbo].[Zhiyzg]
GO
CREATE TABLE [dbo].[Zhiyzg] (
[PKID] int NOT NULL IDENTITY(1,1) ,
[UserID] int NOT NULL ,
[zg] int NULL ,
[hdsj] datetime NULL ,
[zcd] varchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Zhiyzg]', RESEED, 4198)
GO

-- ----------------------------
-- Indexes structure for table BaseInfo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table BaseInfo
-- ----------------------------
ALTER TABLE [dbo].[BaseInfo] ADD PRIMARY KEY ([UserID])
GO

-- ----------------------------
-- Indexes structure for table enuGzsxlb
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuGzsxlb
-- ----------------------------
ALTER TABLE [dbo].[enuGzsxlb] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuHyzk
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuHyzk
-- ----------------------------
ALTER TABLE [dbo].[enuHyzk] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuJsj
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuJsj
-- ----------------------------
ALTER TABLE [dbo].[enuJsj] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuJyjd
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuJyjd
-- ----------------------------
ALTER TABLE [dbo].[enuJyjd] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuLaiy
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuLaiy
-- ----------------------------
ALTER TABLE [dbo].[enuLaiy] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuQwyx
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuQwyx
-- ----------------------------
ALTER TABLE [dbo].[enuQwyx] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuSex
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuSex
-- ----------------------------
ALTER TABLE [dbo].[enuSex] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuWjlx
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuWjlx
-- ----------------------------
ALTER TABLE [dbo].[enuWjlx] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuWy
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuWy
-- ----------------------------
ALTER TABLE [dbo].[enuWy] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuYpbm
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuYpbm
-- ----------------------------
ALTER TABLE [dbo].[enuYpbm] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuYpgw
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuYpgw
-- ----------------------------
ALTER TABLE [dbo].[enuYpgw] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuZc
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuZc
-- ----------------------------
ALTER TABLE [dbo].[enuZc] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuZg
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuZg
-- ----------------------------
ALTER TABLE [dbo].[enuZg] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuZt
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuZt
-- ----------------------------
ALTER TABLE [dbo].[enuZt] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuZy
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuZy
-- ----------------------------
ALTER TABLE [dbo].[enuZy] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table enuZzmm
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table enuZzmm
-- ----------------------------
ALTER TABLE [dbo].[enuZzmm] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table FileInfo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table FileInfo
-- ----------------------------
ALTER TABLE [dbo].[FileInfo] ADD PRIMARY KEY ([FileID])
GO

-- ----------------------------
-- Indexes structure for table Gongzsx
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Gongzsx
-- ----------------------------
ALTER TABLE [dbo].[Gongzsx] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table Jiaoybj
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Jiaoybj
-- ----------------------------
ALTER TABLE [dbo].[Jiaoybj] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table Jiatshgx
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Jiatshgx
-- ----------------------------
ALTER TABLE [dbo].[Jiatshgx] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Indexes structure for table MenuItem
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table MenuItem
-- ----------------------------
ALTER TABLE [dbo].[MenuItem] ADD PRIMARY KEY ([MenuItemID])
GO

-- ----------------------------
-- Indexes structure for table TopMenu
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TopMenu
-- ----------------------------
ALTER TABLE [dbo].[TopMenu] ADD PRIMARY KEY ([TopMenuID])
GO

-- ----------------------------
-- Indexes structure for table zhiwei
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table zhiwei
-- ----------------------------
ALTER TABLE [dbo].[zhiwei] ADD PRIMARY KEY ([pkid])
GO

-- ----------------------------
-- Indexes structure for table Zhiyzg
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Zhiyzg
-- ----------------------------
ALTER TABLE [dbo].[Zhiyzg] ADD PRIMARY KEY ([PKID])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[BaseInfo]
-- ----------------------------
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([hyzk]) REFERENCES [dbo].[enuHyzk] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([jsj]) REFERENCES [dbo].[enuJsj] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([ypzly]) REFERENCES [dbo].[enuLaiy] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([qwxc]) REFERENCES [dbo].[enuQwyx] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([Sex]) REFERENCES [dbo].[enuSex] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([dywy]) REFERENCES [dbo].[enuWy] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([ypbm]) REFERENCES [dbo].[enuYpbm] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([ypgw]) REFERENCES [dbo].[enuYpgw] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([zc]) REFERENCES [dbo].[enuZc] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([zt]) REFERENCES [dbo].[enuZt] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[BaseInfo] ADD FOREIGN KEY ([zzmm]) REFERENCES [dbo].[enuZzmm] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[FileInfo]
-- ----------------------------
ALTER TABLE [dbo].[FileInfo] ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[BaseInfo] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FileInfo] ADD FOREIGN KEY ([wjlx]) REFERENCES [dbo].[enuWjlx] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Gongzsx]
-- ----------------------------
ALTER TABLE [dbo].[Gongzsx] ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[BaseInfo] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Gongzsx] ADD FOREIGN KEY ([gzsxlb]) REFERENCES [dbo].[enuGzsxlb] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Gongzsx] ADD FOREIGN KEY ([cszy]) REFERENCES [dbo].[enuZy] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Jiaoybj]
-- ----------------------------
ALTER TABLE [dbo].[Jiaoybj] ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[BaseInfo] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Jiaoybj] ADD FOREIGN KEY ([jyjd]) REFERENCES [dbo].[enuJyjd] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Jiaoybj] ADD FOREIGN KEY ([sxzy]) REFERENCES [dbo].[enuZy] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Jiatshgx]
-- ----------------------------
ALTER TABLE [dbo].[Jiatshgx] ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[BaseInfo] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Jiatshgx] ADD FOREIGN KEY ([zzmm]) REFERENCES [dbo].[enuZzmm] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[MenuItem]
-- ----------------------------
ALTER TABLE [dbo].[MenuItem] ADD FOREIGN KEY ([TopMenuID]) REFERENCES [dbo].[TopMenu] ([TopMenuID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Zhiyzg]
-- ----------------------------
ALTER TABLE [dbo].[Zhiyzg] ADD FOREIGN KEY ([UserID]) REFERENCES [dbo].[BaseInfo] ([UserID]) ON DELETE CASCADE ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Zhiyzg] ADD FOREIGN KEY ([zg]) REFERENCES [dbo].[enuZg] ([PKID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
