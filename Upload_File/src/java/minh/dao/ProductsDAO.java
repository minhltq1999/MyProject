/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minh.dao;

import java.io.Serializable;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import minh.dto.ProductsDTO;
import minh.util.DBUtils;

/**
 *
 * @author DELL
 */
public class ProductsDAO implements Serializable{
    private Connection con = null;
    private PreparedStatement ps = null;
    private ResultSet rs = null;
    
    private void closeConnection() throws SQLException{
        if (rs != null) {
            rs.close();
        }
        if (ps != null) {
            ps.close();
        }
        if (con != null) {
            con.close();
        }
    }
    
    public List<ProductsDTO> getListProducts() throws SQLException {
        List<ProductsDTO> list = new ArrayList<>();
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String select = "Select name, shortDescription, detailedDescription, price, specialPrice, image from Products";
                ps = con.prepareStatement(select);
                rs = ps.executeQuery();
                while (rs.next()) {                    
                    String name = rs.getString("name");
                    String shortDescription = rs.getString("shortDescription");
                    String detailedDescription = rs.getString("detailedDescription");
                    float price = rs.getFloat("price");
                    float specialPrice = rs.getFloat("specialPrice");
                    String image = rs.getString("image");
                    ProductsDTO dto = new ProductsDTO(name, shortDescription, detailedDescription, price, specialPrice, image);
                    list.add(dto);
                }
            }
        } catch (ClassNotFoundException | SQLException e) {
        } finally {
            closeConnection();
        }
        return list;
    }
    
    public boolean addProducts(ProductsDTO dto) throws SQLException {
        boolean result = false;
        try {
            con = DBUtils.makeConnection();
            if (con != null) {
                String insert = "insert into Products values(?,?,?,?,?,?)";
                ps = con.prepareStatement(insert);
                ps.setString(1, dto.getName());
                ps.setString(2, dto.getShortDescription());
                ps.setString(3, dto.getDetailedDescription());
                ps.setFloat(4, dto.getPrice());
                ps.setFloat(5, dto.getDiscountPrice());
                ps.setString(6, dto.getImage());
                result = ps.executeUpdate() > 0;
                
            }
        } catch (ClassNotFoundException | SQLException e) {
        } finally {
            closeConnection();
        }
        return result;
    }
    
//    public boolean checkImage(String image) throws SQLException {
//        boolean result = false;
//        try {
//            con = DBUtils.makeConnection();
//        } catch (Exception e) {
//        }
//        return result;
//    }
}
