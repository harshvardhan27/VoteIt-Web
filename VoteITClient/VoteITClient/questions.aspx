<%@ Page Title="Question" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="questions.aspx.cs" Inherits="VoteITClient.questions" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-sm-4">
            <h2>Welcome to Vote IT</h2>
            <ol class="breadcrumb">
                <li class="active">
                    <a href="dashboard.aspx">Dashboard</a>
                </li>
                <li class="active">
                    <strong>Questions</strong>
                </li>
            </ol>
        </div>
    </div>
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Add Question</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row panel panel-danger" runat="server" id="errorPanel" visible="false">
                            <div class="panel-heading">
                                <span id="panelHead" runat="server"></span>
                                <button aria-hidden="true" class="close" type="button">×</button>
                            </div>
                            <div class="panel-body">
                                <p id="panelContent" runat="server"></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="col-sm-4 control-label"></asp:Label>
                                    <div class="col-sm-8">
                                        <select data-placeholder="Choose a Category..." class="chosen-select" id="ddlCategory" runat="server">
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lblQuestion" runat="server" Text="Question" CssClass="col-sm-4 control-label"></asp:Label>
                                    <div class="col-sm-8">
                                        <textarea id="txtQuestion" runat="server" class="form-control" rows="5" cols="6" maxlength="200"></textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <div class="col-sm-8 col-sm-offset-4">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                        <input type="reset" class="btn btn-warning" value="Reset" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>


