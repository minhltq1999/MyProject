/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minh.controller;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.FileItemFactory;
import org.apache.commons.fileupload.FileUploadException;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;

/**
 *
 * @author DELL
 */
@WebServlet(name = "TestAddController", urlPatterns = {"/TestAddController"})
public class TestAddController extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        //        boolean multiPart = ServletFileUpload.isMultipartContent(request);
        //        if (!multiPart) {
        //        } else {
        //            FileItemFactory factory = new DiskFileItemFactory();
        //            ServletFileUpload upload = new ServletFileUpload();
        //            List items = null;
        //            try {
        //                items = upload.parseRequest(request);
        //            } catch (FileUploadException e) {
        //            }
        //            Iterator iter = items.iterator();
        //            Hashtable params = new Hashtable();
        //            String fileName = null;
        //            while (iter.hasNext()) {                
        //                FileItem item = (FileItem) iter.next();
        //                if (item.isFormField()) {
        //                    params.put(item.getFieldName(), item.getString());
        //                } else {
        //                    try {
        //                        String itemName = item.getName();
        //                        fileName = itemName.substring(itemName.lastIndexOf("\\" + 1));
        //                        String realPath = getServletContext().getRealPath("/") + "images\\" + fileName;
        //                        File saveFile = new File(realPath);
        //                        item.write(saveFile);
        //                    } catch (Exception e) {
        //                    }
        //                }
        //            }
        //        }

        //        boolean multiPart = ServletFileUpload.isMultipartContent(request);
        //        if (!multiPart) {
        //            
        //        } else {
        //            FileItemFactory factory = new DiskFileItemFactory();
        //            ServletFileUpload upload = new ServletFileUpload();
        //            List items = null;
        //            try {
        //                items = upload.parseRequest(request);
        //            } catch (FileUploadException e) {
        //            }
        //            Iterator iter = items.iterator();
        //            Hashtable params = new Hashtable();
        //            String fileName = null;
        //            while (iter.hasNext()) {                
        //                FileItem item = (FileItem) iter.next();
        //                if (item.isFormField()) {
        //                    params.put(item.getFieldName(), item.getString());
        //                } else {
        //                    String itemName = item.getName();
        //                    fileName = itemName.substring(itemName.lastIndexOf("\\") + 1) ;
        //                    String realPath = getServletContext().getRealPath("/") + "images\\" + fileName;
        //                    File saveFile = new File(realPath);
        //                    try {
        //                        item.write(saveFile);
        //                    } catch (Exception ex) {
        //                        Logger.getLogger(TestAddController.class.getName()).log(Level.SEVERE, null, ex);
        //                    }
        //                }
        //            }
        //        }

        //       boolean multiPart = ServletFileUpload.isMultipartContent(request);
        //        if (!multiPart) {
        //            
        //        } else {
        //            FileItemFactory factory = new DiskFileItemFactory();
        //            ServletFileUpload upload = new ServletFileUpload();
        //            List items = null;
        //            try {
        //                items = upload.parseRequest(request);
        //            } catch (Exception e) {
        //            }
        //            Iterator iter = items.iterator();
        //            Hashtable params = new Hashtable();
        //            String fileName = null;
        //            while (iter.hasNext()) {                
        //                FileItem item = (FileItem) iter.next();
        //                if (item.isFormField()) {
        //                    params.put(item.getFieldName(), item.getString());
        //                } else {
        //                    String itemName = item.getName();
        //                    fileName = itemName.substring(itemName.lastIndexOf("\\") + 1);
        //                    String realPath = getServletContext().getRealPath("/" + "images\\" + fileName);
        //                    File saveFile = new File(realPath);
        //                    try {
        //                        item.write(saveFile);
        //                    } catch (Exception ex) {
        //                        Logger.getLogger(TestAddController.class.getName()).log(Level.SEVERE, null, ex);
        //                    }
        //                }
        //            }
        //        }

        //        boolean multiPart = ServletFileUpload.isMultipartContent(request);
        //        if (!multiPart) {
        //            
        //        } else {
        //            FileItemFactory factory = new DiskFileItemFactory();
        //            ServletFileUpload upload = new ServletFileUpload();
        //            List items = null;
        //            try {
        //                items = upload.parseRequest(request);
        //            } catch (Exception e) {
        //            }
        //            Iterator iter = items.iterator();
        //            Hashtable params = new Hashtable();
        //            String fileName = null;
        //            while (iter.hasNext()) {                
        //                FileItem item = (FileItem) iter.next();
        //                if (item.isFormField()) {
        //                    params.put(item.getFieldName(), item.getString());
        //                } else {
        //                    try {
        //                        String itemName = item.getName();
        //                        fileName = itemName.substring(itemName.lastIndexOf("\\") + 1);
        //                        String realPath = getServletContext().getRealPath("/" + "images\\" + fileName);
        //                        File saveFile = new File(realPath);
        //                        item.write(saveFile);
        //                    } catch (Exception e) {
        //                    }
        //                }
        //            }
        //        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        boolean multiPart = ServletFileUpload.isMultipartContent(request);
        if (!multiPart) {
            
        } else {
            FileItemFactory factory = new DiskFileItemFactory();
            ServletFileUpload upload = new ServletFileUpload();
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
                        File seaveFile = new File(realPath);
                        item.write(seaveFile);
                    } catch (Exception e) {
                    }
                }
            }
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
