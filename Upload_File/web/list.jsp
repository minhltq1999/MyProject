<%-- 
    Document   : list.jsp
    Created on : Sep 23, 2019, 3:17:54 PM
    Author     : DELL
--%>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>List page</title>
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
        <h1>List of product</h1>
        <c:if test="${requestScope.LISTED != null}">
            <div style="width: 750px">
                <c:forEach items="${requestScope.LISTED}" var="dto" varStatus="counter">
                    <div style="float: left; margin-right: 50px">
                        <img src="images/${dto.image}" width="100" height="100"/><br/>

                        <%--<c:if test="${not empty dto.discountPrice}">
                            Price:<font color="gray"><b style="text-decoration: line-through">${dto.price}</b></font><br/>
                        </c:if>

                        <c:if test="${empty dto.discountPrice}">
                            Price: <d>${dto.price}</d><br/>
                            </c:if>

                        Special price: ${dto.discountPrice}<br/>
                        
                        <c:if test="${not empty dto.discountPrice}">
                            Discount: <font color="red">
                            <fmt:formatNumber type="number" 
                                              maxFractionDigits="2" 
                                              value="${(100 - dto.discountPrice / dto.price * 100) * (-1)}"/>  %
                            </font><br/>
                        </c:if>--%>

                        <c:if test="${dto.discountPrice == -1.0}">
                            ${dto.name}<br/>
                            <font color="red">${dto.price} $</font><br/>
                        </c:if>
                        <c:if test="${dto.discountPrice != -1.0}">
                            ${dto.name}<br/>
                            <font color="red">${dto.discountPrice} $</font><br/>
                            <font color="gray"><b style="text-decoration: line-through">${dto.price} $</b></font>
                            <font color="red">
                            <fmt:formatNumber type="number" 
                                              maxFractionDigits="2" 
                                              value="${(100 - dto.discountPrice / dto.price * 100) * (-1)}"/>  %
                            </font><br/>
                        </c:if>
                    </div>
                </c:forEach>
                <br/>
            </div>

        </c:if>


        <c:if test="${empty requestScope.LISTED}">
            <h2>Empty list product.</h2><br/>
        </c:if>
    </body>
</html>
