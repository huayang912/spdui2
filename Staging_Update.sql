-----------2010/8/21-----------------------
alter table DATA_SOURCE_CATEGORY add ACTIVE_FLAG bit null;
update DATA_SOURCE_CATEGORY set active_flag = 1;


CREATE TABLE [dbo].[DATA_SOURCE_CATEGORY_USER](
	[CATEGORY_ID] [int] NOT NULL,
	[USER_ID] [int] NOT NULL,
 CONSTRAINT [PK_DATA_SOURCE_CATEGORY_USER] PRIMARY KEY CLUSTERED 
(
	[CATEGORY_ID] ASC,
	[USER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


-----------2010/8/28-----------------------
alter table DATA_SOURCE_UPLOAD add OWNER_CONFIRM_BY int;
alter table DATA_SOURCE_UPLOAD add OWNER_CONFIRM_DATE datetime;
alter table DATA_SOURCE_UPLOAD add ETL_CONFIRM_BY int;
alter table DATA_SOURCE_UPLOAD add ETL_CONFIRM_DATE datetime;