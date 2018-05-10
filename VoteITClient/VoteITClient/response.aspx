<%@ Page Title="Response" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="response.aspx.cs" Inherits="VoteITClient.response" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-sm-4">
            <h2>Welcome to Vote IT</h2>
            <ol class="breadcrumb">
                <li class="active">
                    <a href="dashboard.aspx">Dashboard</a>
                </li>
                <li class="active">
                    <strong>Response</strong>
                </li>
            </ol>
        </div>
    </div>
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary" runat="server" id="infoPanel" visible="false">
                    <div class="panel-heading">
                        <span id="panelHeadAlert" runat="server"></span>
                    </div>
                    <div class="panel-body">
                        <p id="panelContentAlert" runat="server"></p>
                        <asp:Button ID="btnBack" runat="server" Text="Go Back" OnClick="btnBack_Click" CssClass="btn btn-primary"/>
                    </div>
                </div>
                <div class="panel panel-primary" id="votePanel" runat="server" visible="false">
                    <div class="panel-heading">
                        Suggestion needed. Vote..!! Vote..!!
                    </div>
                    <div class="panel-body">
                        <div class="faq-item">
                            <div class="row">
                                <div class="col-md-9">
                                    <a data-toggle="collapse" href="#faq1" class="faq-question" id="questionContent" runat="server"></a>
                                    <small>Added by <strong><span id="userContent" runat="server"></span></strong></small>
                                </div>
                                <div class="col-md-3">
                                    <span class="small font-bold">Category</span>
                                    <div class="tag-list">
                                        <span class="tag-item" id="categoryContent" runat="server"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="faq1" class="panel-collapse">
                                        <div class="faq-answer">
                                            <asp:RadioButtonList ID="rbAnswerList" runat="server" AutoPostBack="true"></asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 m-t">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>


    </div>
</asp:Content>
