![Alt text](pass-first-setup-android.jpg?raw=true "pass first setup android")

khi mới cài xong rom android, khởi động lên sẽ trải qua bước cài setting ngôn ngữ các thứ, chạy lệnh sau để bỏ qua những bước này và vào thẳng bên trong màn hình app chính

adb shell settings put global device_provisioned 1 & adb shell settings put secure user_setup_complete 1 & adb shell settings put global package_verifier_enable 0 & adb shell reboot
