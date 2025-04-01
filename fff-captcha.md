![watericoncup](f0.png)
&imginstructions=watericoncup
<br><br>

![mask_match](f1.png)
&imginstructions=mask_match
<br><br>

![finger_direction](f2.png)
&imginstructions=finger_direction
<br><br>

![icon_connect](f3.png)
&imginstructions=icon_connect
<br><br>

#Danh Sách Câu Hỏi ( imginstructions )

Xem Tại Đây > https://github.com/nttrung9x/code-linh-tinh/blob/main/imginstructions-03-2025.cs

<br> Cách GET URL và Chuyển Về Base64:
<br> 1. Bạn vào trang hiển thị captcha, click Authen hoặc Next cho nó hiện ra câu hỏi và captcha
<br> 2. Chuột phải vào tấm ảnh đó và chọn "inspect" để hiện ra tab developer debug
<br> 3. Trong tab "Elements" bạn sẽ thấy line debug trong khu vực "iframe"
<br> 4. Bạn nhìn dòng đó hoặc dò lên hoặc dò xuống vài dòng, sẽ thấy element "img" có "backgound-img" có chứa nội dung kiểu "blob:https://xxx",
<br> >>> Ví dụ:
```
<img aria-label="Image 1 of 12." class="sc-7csxyx-1 blHsFq" style="background-image: url(&quot;blob:https://client-api.arkoselabs.com/32dc3326-13bb-48a0-858d-f312bafd2329&quot;);">
```
<br> 	
<br> 
<br> 5. Copy nguyên URL đó, bao gồm cả "blob:", ta có: blob:https://client-api.arkoselabs.com/32dc3326-13bb-48a0-858d-f312bafd2329
<br> 6. Bạn mở thử URL đó trong tab mới của chrome, nếu thấy nó hiện ra ảnh dạng cells tương tự như ở dưới thì có nghĩa là đã GET đúng
<br> 7. Bây giờ bạn chuyển nó về Base64 Là xong
<br> 8. Đoạn code JavaScript Mẫu để chuyển link Blob về Base64:

```
		const getBase64FromUrl = async (url) => {
		  const data = await fetch(url);
		  const blob = await data.blob();
		  return new Promise((resolve) => {
			const reader = new FileReader();
			reader.readAsDataURL(blob); 
			reader.onloadend = () => {
			  const base64data = reader.result;   
			  resolve(base64data);
			}
		  });
		}

	var Base64Code = await getBase64FromUrl("blob:https://client-api.arkoselabs.com/32dc3326-13bb-48a0-858d-f312bafd2329").then(function(base64data) 
	{
		return base64data.split(";base64,")[1];
	});
```
<br> 	
<br> 
<br> Bạn Phải Get Ra Ảnh Như Này Rồi Chuyển Về Base64 Nha:
<br> finger_direction
