
# Captcha69 API Documentation

## API Endpoint

**URL:**  
`https://captcha69.com/in.php`  

**Method:**  
`GET` / `POST`

---

## Required Parameters

- **`method`**: `haha`  
- **`key`**: `point_xxx`  
- **`pageurl`**: URL of the page displaying haha  
- **`sitekey`**: haha sitekey from iframe  

### Optional Proxy Configuration

If you want to use your own proxy (HTTP, HTTPS, SOCKS4, SOCKS5), add the following parameters:  
`&proxy=username:password@123.123.123.123:3128&proxytype=HTTP`

> **Note:** Proxy usage is similar to 2Captcha.

---

## Create Task

### Request
```plaintext
GET/POST: https://captcha69.com/in.php?key=point_xxx&method=haha&pageurl=https://2captcha.com/demo/haha&sitekey=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

### Response
```plaintext
OK|6353b3f407a9b4417aac965d
```

The value `6353b3f407a9b4417aac965d` is the **ID**.

---

## Getting Results

### Request
```plaintext
GET/POST: https://captcha69.com/res.php?key=point_xxx&action=get&id=6353b3f407a9b4417aac965d
```

### Response
If the server has solved the captcha, the response will be:  
```plaintext
OK|P0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYxxxxx...
```

If the server has not solved the captcha yet, the response will be:  
```plaintext
CAPCHA_NOT_READY
```

---

## Notes

- Request the result every **5 seconds** until the server has solved the captcha.
- If the response is `CAPCHA_NOT_READY`, wait 5 seconds and try again.
- The final response will start with `OK|` followed by the **TOKEN** you need to use.

---

## Demo

### Example Request
```plaintext
GET/POST: https://captcha69.com/in.php?key=point_xxx&method=haha&pageurl=https://2captcha.com/demo/haha&sitekey=3ceb8624-1970-4e6b-91d5-70317b70b651
```

### Example Response
```plaintext
OK|6353b3f407a9b4417aac965d
```

### Example Result Request
```plaintext
GET/POST: https://captcha69.com/res.php?key=point_xxx&action=get&id=6353b3f407a9b4417aac965d
```

### Example Result Response
```plaintext
OK|P0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYxxxxx...
```
