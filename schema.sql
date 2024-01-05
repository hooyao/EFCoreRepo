-- sql server ddl, use your own database name
CREATE TABLE MMP.dbo.Parent (
                                Id bigint IDENTITY(1,1) NOT NULL,
                                ParentId uniqueidentifier DEFAULT newid() NOT NULL,
                                CONSTRAINT AK_Parent_ParentId UNIQUE (ParentId),
                                CONSTRAINT PK_Parent PRIMARY KEY (Id)
);

CREATE TABLE MMP.dbo.[Child] (
                                 Id bigint IDENTITY(1,1) NOT NULL,
                                 ParentId uniqueidentifier NULL,
                                 ChildId uniqueidentifier DEFAULT newid() NOT NULL,
                                 CONSTRAINT AK_Child_ChildId UNIQUE (ChildId),
                                 CONSTRAINT PK_Child PRIMARY KEY (Id)
);

ALTER TABLE MMP.dbo.[Child] ADD CONSTRAINT FK_Child_ParentId FOREIGN KEY (ParentId) REFERENCES MMP.dbo.Parent(ParentId);
