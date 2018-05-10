<%@ Page Title="Result" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="VoteITClient.result" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-sm-4">
            <h2>Welcome to Vote IT</h2>
            <ol class="breadcrumb">
                <li class="active">
                    <a href="dashboard.aspx">Dashboard</a>
                </li>
                <li class="active">
                    <strong>Result</strong>
                </li>
            </ol>
        </div>
    </div>
    <div class="wrapper wrapper-content">

        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Questions</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:GridView ID="gvQuestions" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowSorting="true"
                                    HeaderStyle-BackColor="#1ab394" HeaderStyle-ForeColor="#ffffff" BorderColor="#1ab394" RowStyle-BorderColor="#ffffff" BorderStyle="Solid" AllowPaging="true"
                                    PageSize="10" EmptyDataText="No Record Found.!! Click on Add Question link to post new question." OnPageIndexChanging="gvQuestions_PageIndexChanging" OnRowCommand="gvQuestions_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="QUESTION_ID" HeaderText="ID" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="CATEGORY" HeaderText="Category" ItemStyle-Width="30%" />
                                        <asp:BoundField DataField="NAME" HeaderText="Question" ItemStyle-Width="50%" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Result" Text="View Result" ControlStyle-CssClass="btn btn-primary" ItemStyle-Width="10%" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
