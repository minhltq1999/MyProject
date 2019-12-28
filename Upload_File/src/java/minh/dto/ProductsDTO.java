/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package minh.dto;

import java.io.Serializable;

/**
 *
 * @author DELL
 */
public class ProductsDTO implements Serializable{
    private String name, shortDescription, detailedDescription;
    private float price, discountPrice;
    private String image;

    public ProductsDTO(String name, String shortDescription, String detailedDescription, float price, float discountPrice, String image) {
        this.name = name;
        this.shortDescription = shortDescription;
        this.detailedDescription = detailedDescription;
        this.price = price;
        this.discountPrice = discountPrice;
        this.image = image;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getShortDescription() {
        return shortDescription;
    }

    public void setShortDescription(String shortDescription) {
        this.shortDescription = shortDescription;
    }

    public String getDetailedDescription() {
        return detailedDescription;
    }

    public void setDetailedDescription(String detailedDescription) {
        this.detailedDescription = detailedDescription;
    }

    public float getPrice() {
        return price;
    }

    public void setPrice(float price) {
        this.price = price;
    }

    public float getDiscountPrice() {
        return discountPrice;
    }

    public void setDiscountPrice(float discountPrice) {
        this.discountPrice = discountPrice;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
    
}
