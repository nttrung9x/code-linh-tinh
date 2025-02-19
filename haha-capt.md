API: https://xxx.com/in.php

Method Code: GET / POST

+ Parameter:

&method: haha

&key: point_xxx

&pageurl: link web hiển thị haha mà bạn thấy

&sitekey: xem iframe hiển thị haha trong web mà bạn thấy

# Bắt buộc phải có proxy đi kèm:

Sử dụng proxy (HTTP, HTTPS, SOCKS4, SOCKS5) của riêng bạn thì thêm: &proxy=username:password@123.123.123.123:3128&proxytype=HTTP

( Cách dùng y chang 2captcha )

Demo: GET/POST: https://xxx.com/in.php?key=point_xxx&method=haha&pageurl=https://2captcha.com/demo/hahacapt&sitekey=3ceb8624-1970-4e6b-91d5-70317b70b651

Kết quả trả về: OK|6353b3f407a9b4417aac965d

6353b3f407a9b4417aac965d chính là ID

Demo: GET/POST: https://xxx.com/res.php?key=point_xxx&action=get&id=6353b3f407a9b4417aac965d

Mỗi 5s request 1 lần để chờ server giải xong sẽ trả về kết quả

Nếu Server giải chưa xong, sẽ báo là: CAPCHA_NOT_READY

Bạn lại delay 5 giây rồi request lên res.php lại, cho đến khi:

Có kết quả trả về ở dạng: OK|P0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYxxxxx...

P0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYxxxxx... chính là TOKEN cần dùng.





