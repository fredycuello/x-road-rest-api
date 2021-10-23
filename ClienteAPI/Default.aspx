<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClienteAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cliente</h1>
        <p class="lead">Ejemplo de Cliente que consume un servicio de X-Road</p>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Solicitud de permiso de edificación</h2>
            
            <p>
                <a class="btn btn-default" href="SolicitudAprobacion.aspx">Solicitar</a>
            </p>
        </div>
        <div class="col-md-4">
            
        </div>
        <div class="col-md-4">
            
        </div>
    </div>

</asp:Content>
