/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minh.controller;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import minh.dao.ProductsDAO;
import minh.dto.ErrorDTO;
import minh.dto.ProductsDTO;
import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.FileItemFactory;
import org.apache.commons.fileupload.FileUploadException;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;

/**
 *
 * @author DELL
 */
@WebServlet(name = "AddController", urlPatterns = {"/AddController"})
public class AddController extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    private final String SUCCESS = "addProducts.jsp";
    private final String ERROR = "addProducts.jsp";
//    private final String ERROR = "error.html";

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        PrintWriter out = response.getWriter();
        String url = ERROR;
        ErrorDTO error = new ErrorDTO();
        boolean isErr = false;
        try {
            boolean multiPart = ServletFileUpload.isMultipartContent(request);
            if (!multiPart) {
            } else {
                FileItemFactory factory = new DiskFileItemFactory();
                ServletFileUpload upload = new ServletFileUpload(factory);
                List items = null;
                try {
                    items = upload.parseRequest(request);
                } catch (FileUploadException e) {
                }
                Iterator iter = items.iterator();
                Hashtable params = new Hashtable();
                String fileName = null;
                while (iter.hasNext()) {
                    FileItem item = (FileItem) iter.next();
                    if (item.isFormField()) {
                        params.put(item.getFieldName(), item.getString());
                    } else {
                        try {
                            String itemName = item.getName();
                            fileName = itemName.substring(itemName.lastIndexOf("\\") + 1);
                            String realPath = getServletContext().getRealPath("/") + "images\\" + fileName;
                            File saveFile = new File(realPath);
                            item.write(saveFile);
                        } catch (Exception e) {
                            if (!e.toString().isEmpty()) {
                                isErr = true;
                                error.setImageErr("Existed image, add another image !");
                            }
                        }
                    }
                }
                String name = (String) params.get("txtName");
                String shortDesc = (String) params.get("txtShortDesc");
                String detailedDesc = (String) params.get("txtDetailedDesc");
                String price = (String) params.get("txtPrice");
                if (!price.matches("[0-9.]{1,30}")) {
                    isErr = true;
                    error.setFormatPriceErr("Price must be number.");
                } else if (Float.parseFloat(price) < 0.000) {
                    isErr = true;
                    error.setLengthPriceErr("Price must higher or equal 0.000.");
                }
                String specPrice = (String) params.get("txtSpecialPrice");
                if (specPrice.isEmpty()) {
                    specPrice = "-1";
                } else if (!specPrice.matches("[0-9.]{1,30}")) {
                    isErr = true;
                    error.setFormatSpecPriceErr("Price must be number.");
                } else if (Float.parseFloat(specPrice) < 0.000) {
                    isErr = true;
                    error.setLengthSpecPriceErr("Special Price must higher or equal 0.000.");
                } else if (Float.parseFloat(specPrice) > Float.parseFloat(price)) {
                    isErr = true;
                    error.setLengthSpecPriceErr("Special Price must lower than or equal old price.");
                }
                if (isErr) {
                    request.setAttribute("ERROR", error);
                } else {
                    ProductsDTO dto = new ProductsDTO(name, shortDesc, detailedDesc, Float.parseFloat(price), Float.parseFloat(specPrice), fileName);
                    ProductsDAO dao = new ProductsDAO();
                    boolean result = dao.addProducts(dto);
//                System.out.println(result);
                    if (result) {
                        url = SUCCESS;
                    }
                }
            }

        } catch (SQLException e) {
            log("Error at AddController: " + e.toString());
        } finally {
            request.getRequestDispatcher(url).forward(request, response);

        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
