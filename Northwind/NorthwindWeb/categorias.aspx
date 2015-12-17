<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categorias.aspx.cs" Inherits="NorthwindWeb.categorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>Categorías</h1>
        <div>
            <fieldset>
                <legend>Nueva categoría</legend>
                <div>
                    <label for="txtNombre">Nombre:</label>
                    <asp:TextBox runat="server"  ID="txtNombre"/>
                </div>
                <div>
                    <label for="txtDescripcion">Descripción:</label>
                    <asp:TextBox runat="server"  ID="txtDescripcion"/>
                </div>
                <asp:Button Text="Guardar" runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" />
            </fieldset>

        </div>

        <div>

            <asp:TextBox runat="server" ID="txtFiltro" placeholder="Buscar..." />
            <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />

        </div>

        <div>
            <asp:GridView runat="server" ID="gridCategorias"></asp:GridView>

        </div>



    <div>
        
    </div>
    </form>
</body>
</html>
