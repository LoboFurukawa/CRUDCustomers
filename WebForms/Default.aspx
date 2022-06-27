<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <title>Clientes</title>
        <%--added css to asp.net server controls--%>
        <style>
            .button {
                background-color: #4CAF50;
                border: none;
                color: white;
                padding: 15px 32px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                font-size: 16px;
                margin: 4px 2px;
                cursor: pointer;
            }

            .DataGridFixedHeader {
                color: White;
                font-size: 13px;
                font-family: Verdana;
                background-color: yellow
            }

            .grid_item {
                background-color: #E3EAEB;
                border-width: 1px;
                font-family: Verdana;
                border-style: solid;
                font-size: 12pt;
                color: black;
                border: 1px solid black;
            }

            .grid_alternate {
                border-width: 1px;
                font-family: Verdana;
                border-style: solid;
                font-size: 12pt;
                color: black;
                background-color: White;
            }

            .button4 {
                border-radius: 9px;
            }

            input[type=text], select {
                width: 50%;
                padding: 12px 20px;
                margin: 10px 0;
                display: inline-block;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
                font-family: 'Montserrat', sans-serif;
                text-indent: 10px;
                color: blue;
                text-shadow: 0 1px 2px rgba(0, 0, 0, 0.3);
                font-size: 20px;
            }
        </style>
        <%--added css to asp.net server controls--%>

        <%--added script file for asp.net server controls validations--%>
        <script language="javascript" src="../Scripts/Validation.js" type="text/javascript"></script>
        <script language="javascript" type="text/javascript">  
          <%--  function Validation() {
                if (Required('<%=txtName.ClientID%>', 'Name'))
                if (Required('<%=txtSalary.ClientID%>', 'Salary'))
                    if (Required('<%=txtDeptId.ClientID%>', 'Dept ID'))
                            return true;
                return false;
            }--%>
        </script>
        <%--added script file for asp.net server controls validations--%>
    </head>


    <fieldset>
        <legend>Cliente</legend>
        <div class="row">
            <div class="col-md-3">
                <label>CPF *</label>
            </div>
            <div class="col-md-3">
                <label>Nome *</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtCPF" runat="server" placeholder="000.000.000.00"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtName" runat="server" placeholder=""></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <label>RG</label>
            </div>
            <div class="col-md-3">
                <label>Data Expedição</label>
            </div>
            <div class="col-md-3">
                <label>Órgão expedição</label>
            </div>
            <div class="col-md-3">
                <label>UF Expedição</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtRG" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtShippingDate" runat="server" placeholder="00/00/0000">
                </asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="lstDispatchAgency" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="lstUFsCustomers" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <label>Data de Nascimento *</label>
            </div>
            <div class="col-md-3">
                <label>Sexo *</label>
            </div>
            <div class="col-md-3">
                <label>Estado civil *</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtBirthDate" runat="server" placeholder="00/00/0000"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="Selecionar" Value="*" />
                    <asp:ListItem Text="Feminino" Value="F" />
                    <asp:ListItem Text="Masculino" Value="M" />
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="lstMaritalStatus" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <label>CEP *</label>
            </div>
            <div class="col-md-3">
                <label>Rua *</label>
            </div>
            <div class="col-md-3">
                <label>Numero *</label>
            </div>
            <div class="col-md-3">
                <label>Complemento </label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="display: none">
                <asp:TextBox class="form-control" ID="txtIdAddress" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtCEP" runat="server"></asp:TextBox>
                <button class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtStreet" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtNumber" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtComplement" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <label>Bairro *</label>
            </div>
            <div class="col-md-3">
                <label>Cidade *</label>
            </div>
            <div class="col-md-3">
                <label>UF *</label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtNeighborhood" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:TextBox class="form-control" ID="txtCity" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="lstUFs" runat="server"></asp:DropDownList>
                <%--<div class="dropdown">
                        <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                            UF
                                <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </div>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Adicionar" OnClick="btnSubmit_Click"></asp:Button>
                <%--<span class="glyphicon glyphicon-arrow-right"></span>--%>
                <%--<asp:Button ID="Button1" runat="server" class="button button4" Text="Submit"  OnClientClick="javascript:return Validation();"/>--%>
            </div>
        </div>
    </fieldset>
    <fieldset>
        <%--added gridview style layout and functionality  here--%>
        <asp:GridView ID="grdWcfTest" runat="server" AllowPaging="true" CellPadding="2" EnableModelValidation="True"
            ForeColor="red" GridLines="Both" ItemStyle-HorizontalAlign="center" EmptyDataText="There Is No Records In Database!" AutoGenerateColumns="false" Width="1100px"
            HeaderStyle-ForeColor="blue">
            <HeaderStyle CssClass="DataGridFixedHeader" />
            <RowStyle CssClass="grid_item" />
            <AlternatingRowStyle CssClass="grid_alternate" />
            <FooterStyle CssClass="DataGridFixedHeader" />
            <Columns>
                <asp:TemplateField HeaderText="CPF">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblCPF" runat="server" Text='<%#Eval("CPF") %>'>    
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'>    
                        </asp:Label>
                        <asp:Label ID="lblId" runat="server" Visible="false" Text='<%#Eval("Id")%>'>    
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BirthDate">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%#Eval("BirthDate") %>'>    
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CausesValidation="false"
                            CommandArgument='    
                                                <%#Eval("Id") %>'
                            OnCommand="lnkEdit_Command" ToolTip="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CausesValidation="false"
                            CommandArgument='    
                                                    <%#Eval("Id") %>'
                            CommandName="Delete" OnCommand="lnkDelete_Command"
                            OnClientClick="return confirm('Are you sure you want to delete?')" ToolTip="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--added gridview style layout and functionality  here--%>
    </fieldset>

    <br />
    <br />
</asp:Content>
