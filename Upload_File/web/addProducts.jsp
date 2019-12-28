<%-- 
    Document   : addProducts
    Created on : Sep 21, 2019, 2:17:10 PM
    Author     : DELL
--%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Add Product</title>
        <style>
            nav{
                height: 30px;
                display: inline-block;
                width: 100%;
                background:#333399;
                width: 1000px;
            }
            nav a{
                float: left;
                width: 15%;
                font-weight: bold;
                text-decoration: none;
                height: 100%;
                line-height:30px;
                text-align:center;
                color:#CCCCCC;
            }
        </style>
    </head>
    <body>

        <nav>
            <a href="">Home</a>
            <a href="addProducts.jsp">Add Product</a>
            <c:url var="linked" value="MainController">
                <c:param name="btnAction" value="View"/>
            </c:url>
            <a href="${linked}">List product</a>
            <a href="">Ordered product</a>
        </nav>
        <h1>Add Product</h1><br/>
        <form action="AddController" enctype="multipart/form-data" method="post">

            Name <input type="text" name="txtName" value="" required="true"/>
            <font color="red">${requestScope.ERROR.formatNameErr}</font><br/>

            Short Description <input type="text" name="txtShortDesc" value=""/><br/>

            Detailed Description <input type="text" name="txtDetailedDesc" value="" /><br/>

            Price <input type="text" name="txtPrice" value="" required="true"/>
            <font color="red"> ${requestScope.ERROR.formatPriceErr} </font>
            <font color="red">  ${requestScope.ERROR.lengthPriceErr} </font><br/>

            Special Price <input type="text" name="txtSpecialPrice" value="" />
            <font color="red"> ${requestScope.ERROR.formatSpecPriceErr} </font>
            <font color="red"> ${requestScope.ERROR.lengthSpecPriceErr} </font><br/>

            <input type="file" name="txtImage" value="" /><font color="red"> ${requestScope.ERROR.imageErr} </font><br/>
            <input type="submit" value="Add" name="btnAction" />
            <br/>
        </form>

    </body>
</html>
