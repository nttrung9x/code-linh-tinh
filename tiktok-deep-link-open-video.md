Câu hỏi: Các bác ơi làm thế nào để mở một link tiktok bằng ADB với tên package chỉ định nhỉ. Ví dụ em có app tiktok có package là com.ss.android.ugc.trill thì làm thế nào để em mở trực tiếp link https://www.tiktok.com/@xxx/video/xxx với package chỉ định mà nó không vào trình duyệt xong mới nhảy vào tiktok ạ

Trả lời:
adb shell am start -a android.intent.action.VIEW -d '"snssdk1180://aweme/detail/7271887293500148998"'
7271887293500148998: Là Id của video

