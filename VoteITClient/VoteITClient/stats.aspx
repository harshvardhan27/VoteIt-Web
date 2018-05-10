<%@ Page Title="Stats" Language="C#" MasterPageFile="~/Application.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="VoteITClient.stats" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-sm-4">
            <h2>Welcome to Vote IT</h2>
            <ol class="breadcrumb">
                <li class="active">
                    <a href="dashboard.aspx">Dashboard</a>
                </li>
                <li class="active">
                    <strong>Statistics</strong>
                </li>
            </ol>
        </div>
    </div>
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Statistics
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
                            <hr />
                            <div class="row">
                                <div class="col-lg-12">
                                    <div id="faq1" class="panel-collapse">
                                        <p class="faq-question">User's Response</p>
                                        <table class="table m-t">
                                            <tbody>
                                                <tr style="width: 100%">
                                                    <td style="width: 20%">
                                                        <button type="button" class="btn btn-primary m-r-sm"><span id="stronglyAgree" runat="server"></span></button>
                                                        Strongly Agree
                                                    </td>
                                                    <td style="width: 20%">
                                                        <button type="button" class="btn btn-info m-r-sm"><span id="agree" runat="server"></span></button>
                                                        Agree
                                                    </td>
                                                    <td style="width: 20%">
                                                        <button type="button" class="btn btn-success m-r-sm"><span id="nietherAgreeNorDisagree" runat="server"></span></button>
                                                        Neither Agree nor Disagree
                                                    </td>
                                                    <td style="width: 20%">
                                                        <button type="button" class="btn btn-warning m-r-sm"><span id="disagree" runat="server"></span></button>
                                                        Disagree
                                                    </td>
                                                    <td style="width: 20%">
                                                        <button type="button" class="btn btn-danger m-r-sm"><span id="stronglyDisagree" runat="server"></span></button>
                                                        Strongly Disagree
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 m-t">
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
