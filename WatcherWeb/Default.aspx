<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WatcherWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
       

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">

    <asp:Panel ID="panelContent" GroupingText="ContentPage Controls" runat="server">
        <canvas id="result" width="400" height="400"></canvas>
        <asp:TextBox ID="txtContent" runat="server"></asp:TextBox>
        <asp:Button ID="btnContent" runat="server" Text="Button" OnClientClick="Populate();" />
    </asp:Panel>
    <script type="text/javascript" language="javascript">
        function Populate() {
            {
                var chat = $.connection.tachyon;
                chat.server.send('uday', 'message'));

                chat.client.addNewMessageToPage = function (name, message) {

                    var canvas = document.getElementById("result");
                    var ctx = canvas.getContext("2d");
                    ctx.clearRect(0, 0, canvas.width, canvas.height);
                    ctx.font = "30px Comic Sans MS";
                    ctx.fillStyle = "red";
                    ctx.textAlign = "center";

                    ctx.fillText(message.length, canvas.width / 2, canvas.height / 2);
                }

                document.getElementById('<%=txtContent.ClientID%>').value = "Hi";        
                
            }
        }
    </script>

    <script>
        $(function () {
            // Reference the auto-generated proxy for the hub.
            var chat = $.connection.Tachyon;
            // Create a function that the hub can call back to display messages.

            var counter = 1;
            var items = 30;
            var _val = 1;

         

            chat.client.addNewMessageToPage = function (name, message) {

                var canvas = document.getElementById("result");
                var ctx = canvas.getContext("2d");
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                ctx.font = "30px Comic Sans MS";
                ctx.fillStyle = "red";
                ctx.textAlign = "center";

                ctx.fillText(message.length, canvas.width / 2, canvas.height / 2);



                //ctx.strokeText( message.length,10,50);

                // Add the message to the page.

                //if ( $('#discussion').children().length < items)
                //{
                //    //$('#discussion').append('<li><strong>' + htmlEncode(counter++) + '</strong>: ' + htmlEncode(message) + '</li>');
                //    //$('#discussion').append('<li>' + '#'.repeat(counter++) + '</li>');
                //    //if (counter > items)
                //    //{
                //    //    counter = 1;
                //    //}

                //    $('#discussion').append('<li>' + htmlEncode(message) + '</li>');
                    
                //}
                //else 
                //{
                //    $('#discussion').empty();

                //    //$('ol li:nth-child(' + (counter++ % items) + ')').add("+");

                //}
                
            };
            // Get the user name and store it to prepend to messages.
            //$('#displayname').val(prompt('Enter your name:', ''));
            // Set initial focus to message input box.
            //$('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub.
                    chat.server.send($('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        });
        // This optional function html-encodes messages for display in the page.
        function htmlEncode(value) {
            var encodedValue = $('<div />').text(value).html();
            return encodedValue;
        }
    </script>


        <!--
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>

         -->

    </div>

           

</asp:Content>
