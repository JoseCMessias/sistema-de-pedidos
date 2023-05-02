IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [CodigoBarra] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [Valor] decimal(18,2) NOT NULL,
    [TipoProduto] int NOT NULL,
    [Ativo] bit NOT NULL,
    [Nome] VARCHAR(80) NOT NULL,
    [Telefone] CHAR(11) NOT NULL,
    [Cep] CHAR(8) NOT NULL,
    [Cidade] nvarchar(60) NOT NULL,
    [Estado] CHAR(8) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Telefone] decimal(18,2) NOT NULL,
    [Cep] decimal(18,2) NOT NULL,
    [Estado] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [CodigoBarra] VARCHAR(80) NOT NULL,
    [Descricao] CHAR(11) NOT NULL,
    [Valor] float NOT NULL,
    [Ativo] bit NOT NULL,
    [TipoProduto] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pedido] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [IniciadoEm] datetime2 NOT NULL,
    [FinalizadoEm] datetime2 NOT NULL,
    [TipoFrete] int NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    [Observacao] CHAR(52) NOT NULL,
    [FinalizadoEM] datetime2 NOT NULL,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PedidoItem] (
    [Id] int NOT NULL IDENTITY,
    [PedidoId] int NOT NULL,
    [Quantidade] int NOT NULL DEFAULT 1,
    [Desconto] float NOT NULL,
    [Valor] float NOT NULL,
    [ProdutoId] int NOT NULL,
    CONSTRAINT [PK_PedidoItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidoItem_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidoItem_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Pedido_ClienteId] ON [Pedido] ([ClienteId]);
GO

CREATE INDEX [IX_PedidoItem_PedidoId] ON [PedidoItem] ([PedidoId]);
GO

CREATE INDEX [IX_PedidoItem_ProdutoId] ON [PedidoItem] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230502133306_NovaMigration', N'6.0.5');
GO

COMMIT;
GO

