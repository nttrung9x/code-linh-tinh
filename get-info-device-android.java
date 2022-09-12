package com.mmo69.android.device.info;

import android.os.Build;
import android.util.DisplayMetrics;
/*
https://www.facebook.com/hkvn9x
skype: nttrung9x
https://mmo69.com
telegram: hkvn9x
*/
public class Emyeusss7 {
  public static Map<String, String> GetFullAndroidInfoDevice(Context context) {
          String details="";
          Map<String, String> map = new HashMap<String, String>();
          try {
              /*details+="OS version: "+System.getProperty("os.version").toString()+"\n";
              details+="API Level: "+android.os.Build.VERSION.SDK.toString()+"\n";
              details+="Device: "+android.os.Build.DEVICE.toString()+"\n";
              details+="Model: "+android.os.Build.MODEL.toString()+"\n";
              details+="Product: "+android.os.Build.PRODUCT.toString()+"\n";*/
              map.put("Emyeusss7_OS_version", System.getProperty("os.version").toString());
              map.put("Emyeusss7_API_Level", android.os.Build.VERSION.SDK.toString());
              map.put("Emyeusss7_Device", android.os.Build.DEVICE.toString());
              map.put("Emyeusss7_Model", android.os.Build.MODEL.toString());
              map.put("Emyeusss7_Product", android.os.Build.PRODUCT.toString());
          }
          catch (Exception ex) {
              ex.printStackTrace();
          }
          try {
              /*details+= "VERSION.RELEASE : "+ Build.VERSION.RELEASE
                      +"\nVERSION.INCREMENTAL : "+Build.VERSION.INCREMENTAL
                      +"\nVERSION.SDK.NUMBER : "+Build.VERSION.SDK_INT
                      +"\nBOARD : "+Build.BOARD
                      +"\nBOOTLOADER : "+Build.BOOTLOADER
                      +"\nBRAND : "+Build.BRAND
                      +"\nCPU_ABI : "+Build.CPU_ABI
                      +"\nCPU_ABI2 : "+Build.CPU_ABI2
                      +"\nDISPLAY : "+Build.DISPLAY
                      +"\nFINGERPRINT : "+Build.FINGERPRINT
                      +"\nHARDWARE : "+Build.HARDWARE
                      +"\nHOST : "+Build.HOST
                      +"\nID : "+Build.ID
                      +"\nMANUFACTURER : "+Build.MANUFACTURER
                      +"\nMODEL : "+Build.MODEL
                      +"\nPRODUCT : "+Build.PRODUCT
                      +"\nSERIAL : "+Build.SERIAL
                      +"\nTAGS : "+Build.TAGS
                      +"\nTIME : "+Build.TIME
                      +"\nTYPE : "+Build.TYPE
                      +"\nUNKNOWN : "+Build.UNKNOWN
                      +"\nUSER : "+Build.USER+"\n";*/

              map.put("Emyeusss7_VERSION_RELEASE",Build.VERSION.RELEASE );
              map.put("Emyeusss7_VERSION_INCREMENTAL", Build.VERSION.INCREMENTAL);
              map.put("Emyeusss7_VERSION_SDK_NUMBER", String.valueOf(Build.VERSION.SDK_INT));
              map.put("Emyeusss7_BOARD", Build.BOARD);
              map.put("Emyeusss7_BOOTLOADER", Build.BOOTLOADER);
              map.put("Emyeusss7_BRAND", Build.BRAND);
              map.put("Emyeusss7_CPU_ABI", Build.CPU_ABI);
              map.put("Emyeusss7_CPU_ABI2", Build.CPU_ABI2);
              map.put("Emyeusss7_DISPLAY", Build.DISPLAY);
              map.put("Emyeusss7_FINGERPRINT", Build.FINGERPRINT);
              map.put("Emyeusss7_HARDWARE", Build.HARDWARE);
              map.put("Emyeusss7_HOST", Build.HOST);
              map.put("Emyeusss7_ID", Build.ID);
              map.put("Emyeusss7_MANUFACTURER", Build.MANUFACTURER);
              map.put("Emyeusss7_MODEL", Build.MODEL);
              map.put("Emyeusss7_PRODUCT", Build.PRODUCT);
              map.put("Emyeusss7_SERIAL", Build.SERIAL);
              map.put("Emyeusss7_TAGS", Build.TAGS);
              map.put("Emyeusss7_TIME", String.valueOf(Build.TIME));
              map.put("Emyeusss7_TYPE", Build.TYPE);
              map.put("Emyeusss7_UNKNOWN", Build.UNKNOWN);
              map.put("Emyeusss7_USER", Build.USER);
          }
          catch (Exception ex) {
              //ex.printStackTrace();
          }
          try {
              // MyApplication.java is main application class
              int width= context.getResources().getDisplayMetrics().widthPixels;
              map.put("Emyeusss7_ScreenWidth", String.valueOf(width));
              //details+="ScreenWidth: "+String.valueOf(width)+"\n";
              int height= context.getResources().getDisplayMetrics().heightPixels;
              map.put("Emyeusss7_ScreenHeight", String.valueOf(height));
              //details+="ScreenHeight: "+String.valueOf(height)+"\n";
          }
          catch (Exception ex) {
              //ex.printStackTrace();
          }
          try {
              DisplayMetrics metrics = context.getResources().getDisplayMetrics();
              int densityDpi = (int)(metrics.density * 160f);
              //details+="Density: "+String.valueOf(metrics.density)+"\n";
              //details+="DensityDpi: "+String.valueOf(densityDpi)+"\n";
              map.put("Emyeusss7_Density", String.valueOf(metrics.density));
              map.put("Emyeusss7_DensityDpi", String.valueOf(densityDpi));
          }
          catch (Exception ex) {
              //ex.printStackTrace();
          }
          //return details;
          return map;
      }
}
