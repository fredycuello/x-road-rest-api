<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SolicitudAprobacion.aspx.cs" Inherits="RestApi.SolicitudAprobacion" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script type="text/javascript">
       

    </script>

    <style>
        .bg-warning {
            background-color: rgb(255 204 153);
        }
    </style>

        
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3><center>SOLICITUD: APROBACIÓN DE ANTEPROYECTO DE OBRAS DE EDIFICACIÓN</center></h3>
    <h4><center>OBRA NUEVA</center></h4>
    <center>DIRECCIÓN DE OBRAS MUNICIPALES DE: Casa Blanca</center>
       
        
    <div class="container table-bordered">

        
        <div class="row table-bordered">
            <label for="DropDownList1" class="col-form-label col-sm-1">Región</label>
            
            <asp:DropDownList class="form-control col-sm-6" ID="DropDownList1" runat="server" >
                <asp:ListItem Text="--Seleccione una región--">          
                </asp:ListItem>
                <asp:ListItem Text="region 1">          
                </asp:ListItem>
                <asp:ListItem Text ="region 2">          
                </asp:ListItem>

            </asp:DropDownList>
       </div>
            <br />
 
        <div class="row">
            <div class="col-sm-3">
                <h4>ANTECEDENTES PREVIOS</h4>
            </div>
        </div>
        <div class="row bg-warning">
            <div class="col-md-3  bg-warning" >
                <label for="nombreproyecto" class="" >Nombre del proyecto</label>
            </div>
            <div class="col-md-9 ">
                <input type="text" id="nombreproyecto" class="form-control"/>
            </div>
        </div>
        <div class="row bg-warning">
            <div class="col-md-12  bg-warning" >
                <label for="" class="" >Certificado de Informaciones Previas</label>
            </div>
        </div>
        <div class="row bg-warning">
            <div class="col-md-2  bg-warning" >
                <label class="" >Número</label>
            </div>

            <div class="col-md-2  bg-warning" >
                <label class="" >De Fecha</label>
            </div>

            <div class="col-md-2  bg-warning" >
                <label class="" >ROL</label>
            </div>

            


            

            
        </div>

        <div class="row bg-warning">
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxNumeroPrevio" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>

            <div class="col-md-2 ">
                <input type="date" class="form-control " id="FechaPrevia" runat="server"/>
            </div>

            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRolInfoPrevia" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-2 ">
                <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="Button1_Click" />
            </div>

            <div class="col-md-2 ">
                <asp:Button ID="Button5" runat="server" Text="Descargar documento" CssClass="btn btn-secondary" OnClick="Button5_Click" />
            </div>

        </div>

        <br />
        <div class="row">
            <h4>1 DATOS DE LA PROPIEDAD</h4>
        </div>

        <div class="row bg-warning">
            <div class="col-md-3 ">
                <label runat="server" class="" >Dirección: nombre vía</label>
            </div>
            <div class="col-md-1 ">
                <label runat="server" class="" >N°</label>
            </div>
            <div class="col-md-3 ">
                <label runat="server" class="" >N° Local/ Of / Depto</label>
            </div>
            <div class="col-md-3 ">
                <label runat="server" class="" >ROL</label>
            </div>
        </div>
        <div class="row bg-warning">
            <div class="col-md-3 ">
                <asp:TextBox ID="TextBoxDireccionVia" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 ">
                <asp:TextBox ID="TextBoxDireccionNumero" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                <asp:TextBox ID="TextBoxDireccionNumeroLocal" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                <asp:TextBox ID="TextBoxRolPropiedad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:Button ID="BuscarPropiedad" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="BuscarPropiedad_Click" />
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-1 ">
                <label runat="server" class="" >Manzana</label>
            </div>
            <div class="col-md-1 ">
                <label runat="server" class="" >Lote</label>
            </div>
            <div class="col-md-3 ">
                <label runat="server" class="" >Población/Villa/Loteo</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >Localidad</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >Plano de loteo N°</label>
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-1 ">
                <asp:TextBox ID="TextBoxManzana" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1 ">
                <asp:TextBox ID="TextBoxLote" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                <asp:TextBox ID="TextBoxPoblacion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxPlanoLoteo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <br />

        <div class="row">
            <h4>2 DECLARACIÓN JURADA COMPRADOR O PROMITENTE COMPRADOR</h4>
        </div>
    
        <div class="row bg-warning">
        </div>
    
    
        <br />

        <div class="row">
            <h4>3 DATOS DEL PROPIETARIO O PROMITENTE COMPRADOR</h4>
        </div>
    
        <div class="row bg-warning">
            <div class="col-md-5 ">
                <label runat="server" class="" >NOMBRE O RAZÓN SOCIAL DEL PROPIETARIO O PROMITENTE COMPRADOR</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >R.U.T</label>
            </div>
            
            
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <asp:TextBox ID="TextBoxNombrePropietario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRutPropietario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                
                <asp:Button ID="ButtonBuscarRUT1" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="ButtonBuscarRUT1_Click" />
            
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <label runat="server" class="" >REPRESENTANTE LEGAL DEL PROPIETARIO</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >R.U.T</label>
            </div>
            
            
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <asp:TextBox ID="TextBoxRepresentante" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRutRepresentante" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                
                <asp:Button ID="ButtonBuscarRutRepresentante" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="ButtonBuscarRutRepresentante_Click"/>
            
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-3 ">
                <label runat="server" class="" >DIRECCIÓN: Nombre de la vía</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >N°</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >Local/ Of/ Depto</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >Localidad</label>
            </div>
            
            
        </div>

        <div class="row bg-warning">
            <div class="col-md-3 ">
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>
        
        <br />
        
        <div class="row">
            <h4>4 DATOS PROFESIONALES RESPONSABLES</h4>
        </div>
    
        <div class="row bg-warning">
            <div class="col-md-5 ">
                <label runat="server" class="" >NOMBRE O RAZÓN SOCIAL DE LA EMPRESA DE ARQUITECTURA(cuando corresponda)</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >R.U.T</label>
            </div>
            
           
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <asp:TextBox ID="TextBoxNombreEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRutEmpresa" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                
                <asp:Button ID="ButtonEmpresa" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="ButtonEmpresa_Click"  />
            
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <label runat="server" class="" >NOMBRE ARQUITECTO</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >R.U.T</label>
            </div>
            
        </div>

        <div class="row bg-warning">
            <div class="col-md-5 ">
                <asp:TextBox ID="TextBoxNombreArquitecto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRutArquitecto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="col-md-3 ">
               <asp:Button ID="ButtonBuscarProfesional" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="ButtonBuscarProfesional_Click" />
            </div>

        </div>

        <div class="row bg-warning">        
            <div class="col-md-2 ">
                <label runat="server" class="" >PATENTE PROFESIONAL</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >FECHA</label>
            </div>
        </div>

        <div class="row bg-warning">
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxPatente" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxFechaPatente" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-2 ">
                <asp:CheckBox ID="CheckBoxVigente" runat="server" Text="Vigente?"/>
            </div>

        </div>
        

        <div class="row">
            <h4>5 FACTIBILIDAD DE DACIÓN DE AGUA Y ALCANTARILLADO </h4>
        </div>
    
        <div class="row bg-warning">
            <div class="col-md-2 ">
                <label runat="server" class="" >Factibilidad</label>
            </div>
            <div class="col-md-2 ">
                <label runat="server" class="" >ROL</label>
            </div>
            
           
        </div>

        <div class="row bg-warning">
            <div class="col-md-2 ">
                <asp:CheckBox ID="CheckBoxFactibilidad" runat="server" Text="Es Factible?"/>
            </div>
            <div class="col-md-2 ">
                <asp:TextBox ID="TextBoxRolFactibilidad" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3 ">
                
                <asp:Button ID="ButtonBuscarFactibilidad" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="ButtonBuscarFactibilidad_Click"  />
            
            </div>
        </div>


        <br />

        <div class="row">
            <div class="col">
                <asp:TextBox ID="TextBoxMensajes" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
            
    </div>


</asp:Content>

