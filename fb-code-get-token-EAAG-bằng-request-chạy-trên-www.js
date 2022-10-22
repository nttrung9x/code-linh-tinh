// code get token EAAG bằng request chạy trên www
// share by https://www.facebook.com/boynb98
// update ngày 05-10-2022

(async function () {
    let user_code = ''
    let encrypted_post_body = ''
    let logger_id = ''
    let code = ''
    let code_get_token = ''
    let fb_dtsg = require('DTSGInitialData').token
    let uid = require('CurrentUserInitialData').USER_ID

    await fetch("https://graph.facebook.com/v2.6/device/login", {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        "body": "scope=&access_token=437340816620806|04a36c2558cde98e185d7f4f701e4d94",
        "method": "POST",
    }).then(res => res.json())
        .then(res => {
            user_code = res.user_code
            code_get_token = res.code
        })

    await fetch('https://www.facebook.com/oauth/device/authorize/', {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        'referrer': 'https://www.facebook.com/devices',
        'referrerPolicy': 'origin-when-cross-origin',
        'body': `jazoest=25405&fb_dtsg=${fb_dtsg}&user_code=${user_code}&qr=&__user=${uid}&__a=1&__dyn=&__csr=&__req=b&__hs=19183.BP%3ADEFAULT.2.1.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1005818450&__s=4pbx7n%3Alw7vmo%3A7veo8o&__hsi=7118777193805080277&__comet_req=0&lsd=VV7ZePyNTjgCDWP2PcV1rr&__spin_r=1005818450&__spin_b=trunk&__spin_t=1657469476`,
        'method': 'POST',
        'mode': 'cors',
        'credentials': 'include'
    }).then(res => res.text());

    await fetch(`https://www.facebook.com/dialog/oauth?client_id=437340816620806&scope=user_birthday%2C%20user_hometown%2C%20user_likes%2C%20user_photos%2C%20user_videos%2C%20user_friends%2C%20user_posts%2C%20user_gender%2C%20user_link%2C%20user_age_range%2C%20email%2C%20read_custom_friendlists%2C%20read_insights%2C%20whitelisted_offline_access%2C%20publish_video%2C%20publish_to_groups%2C%20groups_access_member_info%2C%20pages_read_engagement%2C%20pages_manage_metadata%2C%20pages_read_user_content%2C%20pages_manage_ads%2C%20public_profile&force_confirmation=true&auth_type=rerequest&ref=DeviceAuth&user_code=${user_code}&state=f1108389dcbf78&redirect_uri=https%3A%2F%2Fwww.facebook.com%2Fdialog%2Freturn%2Farbiter&display=async`, {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        'referrer': 'https://www.facebook.com/devices',
        'referrerPolicy': 'origin-when-cross-origin',
        'body': `__asyncDialog=1&__user=${uid}&__a=1&__dyn=&__csr=&__req=8&__hs=19183.BP%3ADEFAULT.2.1.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1005818450&__s=8wsbrp%3Alw7vmo%3Amygejy&__hsi=7118766960420679619&__comet_req=0&fb_dtsg=${fb_dtsg}&jazoest=25391&lsd=AqOHzsCi3NB4mxqmhGU19Q&__spin_r=1005818450&__spin_b=trunk&__spin_t=1657467093`,
        'method': 'POST',
        'mode': 'cors',
        'credentials': 'include'
    }).then(res => res.text())
        .then(r => {
            encrypted_post_body = r.match(/encrypted_post_body":"(.+?)"/)[1];
            logger_id = r.match(/logger_id":"(.+?)"/)[1]
        });

    await fetch('https://www.facebook.com/v2.0/dialog/oauth/confirm/', {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        'referrer': 'https://www.facebook.com/devices',
        'referrerPolicy': 'origin-when-cross-origin',
        'body': `jazoest=25391&fb_dtsg=${fb_dtsg}&push_read=&push_link=&deduplicate=&link_customer_account=&read=&link_news_subscription=&write=&extended=&confirm=&reauthorize=&user_messenger_contact=&user_pay_preference=&auth_nonce=&auth_type=rerequest&calling_package_key=&default_audience=&dialog_type=gdp_comet&display=async&domain=&extras=&facebook_sdk_version=&fallback_redirect_uri=&fbapp_pres=&install_nonce=&logged_out_behavior=&logger_id=${logger_id}&l_nonce=&messenger_page_id=&nonce=&reset_messenger_state=&ret=&return_format=code&return_scopes=&scope=email%2Cread_custom_friendlists&sdk=&sdk_version=&sso_device=&tp=unspecified&user_code=${user_code}&page_id_account_linking=&encrypted_post_body=${encrypted_post_body}&seen_scopes=&cbt=1657467103452&window_height=961&window_width=762&__user=${uid}&__a=1&__dyn=7AzHK4HUHxp2oqGQV8CC5EW3mbwyyQjFwLBwCzob9U98nwgU6C7UW3eECdxy7HzE4q3yczobo9E98pxy48nwvoiyEqx60xUnwho2VwgE7Oq7ooxu1ZgC11x-9w9278jw8qbzoiAwVUa8rU8UlzUO2e0KawjokxWeKdwGwQwnEOUbE984uq2l2Utx6ewi8y0CpUmwnEfo4a4Hy8kwQzXxG1Pxi4UbUC2G1NwkEbElxm4E5y2a5U4q0F8G58G0hG4EtzUdEGdwzwea0Lo4K2e1Fw&__csr=&__req=9&__hs=19183.BP%3ADEFAULT.2.1.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1005818450&__s=8wsbrp%3Alw7vmo%3Amygejy&__hsi=7118766960420679619&__comet_req=0&lsd=AqOHzsCi3NB4mxqmhGU19Q&__spin_r=1005818450&__spin_b=trunk&__spin_t=1657467093`,
        'method': 'POST',
        'mode': 'cors',
        'credentials': 'include'
    }).then(res => res.text())
        .then(r => {
            code = r.match(/code":"(.+?)"/)[1]
        });

    await fetch('https://www.facebook.com/ajax/oauth/device.php', {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        'referrer': 'https://www.facebook.com/devices',
        'referrerPolicy': 'origin-when-cross-origin',
        'body': `user_code=${user_code}&code=${code}&auth_method=manual_entry&__user=${uid}&__a=1&__dyn=&__csr=&__req=e&__hs=19183.BP%3ADEFAULT.2.1.0.0.0&dpr=1&__ccg=EXCELLENT&__rev=1005818450&__s=4pbx7n%3Alw7vmo%3A7veo8o&__hsi=7118777193805080277&__comet_req=0&fb_dtsg=${fb_dtsg}&jazoest=25405&lsd=VV7ZePyNTjgCDWP2PcV1rr&__spin_r=1005818450&__spin_b=trunk&__spin_t=1657469476`,
        'method': 'POST',
        'mode': 'cors',
        'credentials': 'include'
    }).then(res => res.text());

    await fetch("https://graph.facebook.com/v2.6/device/login_status", {
        'headers': {
            'content-type': 'application/x-www-form-urlencoded',
        },
        "body": `access_token=437340816620806|04a36c2558cde98e185d7f4f701e4d94&code=${code_get_token}&method=post`,
        "method": "POST",
    }).then(res => res.json())
        .then(res => {
            if (res.access_token) {
                prompt('ACCESS_TOKEN', res.access_token)
            } else {
                alert('Lỗi không thể get token')
            }
        })
})()

