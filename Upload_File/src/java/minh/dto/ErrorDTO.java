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
public class ErrorDTO implements Serializable{
    private String lengthNameErr, formatNameErr, formatPriceErr, lengthPriceErr,
            formatSpecPriceErr, lengthSpecPriceErr, imageErr, alertErr;

    public ErrorDTO() {
    }

    public String getAlertErr() {
        return alertErr;
    }

    public void setAlertErr(String alertErr) {
        this.alertErr = alertErr;
    }
    
    

    public String getImageErr() {
        return imageErr;
    }

    public void setImageErr(String imageErr) {
        this.imageErr = imageErr;
    }
    
    

    public String getLengthNameErr() {
        return lengthNameErr;
    }

    public void setLengthNameErr(String lengthNameErr) {
        this.lengthNameErr = lengthNameErr;
    }

    public String getFormatNameErr() {
        return formatNameErr;
    }

    public void setFormatNameErr(String formatNameErr) {
        this.formatNameErr = formatNameErr;
    }

    public String getFormatPriceErr() {
        return formatPriceErr;
    }

    public void setFormatPriceErr(String formatPriceErr) {
        this.formatPriceErr = formatPriceErr;
    }

    public String getLengthPriceErr() {
        return lengthPriceErr;
    }

    public void setLengthPriceErr(String lengthPriceErr) {
        this.lengthPriceErr = lengthPriceErr;
    }

    public String getFormatSpecPriceErr() {
        return formatSpecPriceErr;
    }

    public void setFormatSpecPriceErr(String formatSpecPriceErr) {
        this.formatSpecPriceErr = formatSpecPriceErr;
    }

    public String getLengthSpecPriceErr() {
        return lengthSpecPriceErr;
    }

    public void setLengthSpecPriceErr(String lengthSpecPriceErr) {
        this.lengthSpecPriceErr = lengthSpecPriceErr;
    }
    
}
