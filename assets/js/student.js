$(function() {

    // 初始化: 瀑布流布局
    var $container = $('.thumbnails');
    $container.imagesLoaded(function() {
        $container.masonry({
            itemSelector: 'li.span3'
        });
    });

    // 当点击学院tab的时候，触发该事件，
    // reload瀑布流布局，防止因取不到image的width, height, 造成页面混乱
    $('#college_select a[data-toggle="tab"]').on('shown', function(e) {
        $($(this).attr("href")).find('.thumbnails').masonry('reload');
    });

    // 初始化：详细资料 浮出框a[data-toggle="tab"]
    $('a[rel="popover"]').popover();

    $('#college_select a[data-toggle="tab"]').click(function() {
        $("#ctl00_ctl00_ContentPlaceHolder2_ContentPlaceHolder1_DropDownListCollege").val($(this).text());
        setTimeout('__doPostBack(\'ctl00$ctl00$ContentPlaceHolder2$ContentPlaceHolder1$DropDownListCollege\',\'\')', 0)
    });

    // 事件绑定：选定按钮
    $('.thumbnail .confirm .btn-group li').live('click', function() {
        var self = $(this);
        var choice = self.find('a').data('choice');
        var val = self.closest('.dropdown-menu').find('input').val();

        /* 这里先要判断是否会覆盖已选的志愿,若会，则给予提示 */
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: "volunteer.aspx/volunteer_select",
            data: "{priority:'" + choice + "'}",
            dataType: "json",
            success: function(result) {
                var data = $.parseJSON(result.d);
                if (data.msg === "yes") {
                    var rs = confirm('将覆盖第 ' + choice + ' 志愿的导师 ' + data.tname.trim() + ' ，确定吗？');
                    if (rs) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            url: "volunteer.aspx/volunteer_update",
                            data: "{tno:'" + val + "',priority:'" + choice + "'}",
                            dataType: "json",
                            success: function(update) {
                                alert(update.d);
                            }
                        });
                    }
                    // 取消按钮，中断该操作
                    if (!rs) return false;
                }
                else {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "volunteer.aspx/volunteer_insert",
                        data: "{tno:'" + val + "',priority:'" + choice + "'}",
                        dataType: "json",
                        success: function(update) {
                            alert(update.d);
                        }
                    });
                }
            }
        });
        // TODO 发送请求
        //$.post(url, params, function(){});
    });


    /*  照片裁剪 */
    // 照片大小
    var avatar_width = 225,
        avatar_height = 300;
    // Create variables (in this scope) to hold the API and image size
    var jcrop_api, boundx, boundy;

    // 裁剪后的效果图预览
    var updatePreview = function(c) {
        if (parseInt(c.w) > 0) {
            var rx = avatar_width / c.w;
            var ry = avatar_height / c.h;

            $('.avatar_preview img').css({
                width: Math.round(rx * boundx) + 'px',
                height: Math.round(ry * boundy) + 'px',
                marginLeft: '-' + Math.round(rx * c.x) + 'px',
                marginTop: '-' + Math.round(ry * c.y) + 'px'
            });
        }
    };

    var $crop_container = $('#my_avatar');

    // 渲染被裁剪的(上传)图片
    var regCropAvatar = function() {
        $('#my_avatar img').Jcrop({
            minSize: [10, 10], 	// 裁剪的最小宽度、高度
            maxSize: [avatar_width, avatar_height], // 裁剪的最大宽度、高度
            setSelect: [0, 0, avatar_width, avatar_height], // 设置 默认选中区域的左上角、右下角坐标
            onSelect: updatePreview,
            onChange: updatePreview,
            onRelease: function() { },
            aspectRatio: 0.75	// 等比缩放
        }, function() { // callback
            // Use the API to get the real image size
            var bounds = this.getBounds();
            boundx = bounds[0];
            boundy = bounds[1];
            // Store the API in the jcrop_api variable
            jcrop_api = this;
        });
    };

    /* 照片上传前预览 */
    var $input_file = $('form#upload_avatar input:file');
    $input_file.bind('change', function(e) {
        e = e.originalEvent;
        e.preventDefault();
        window.loadImage(
			(e.dataTransfer || e.target).files[0],
			function(img) { // callback
			    $crop_container.children().replaceWith(img);
			    $('.avatar_preview').children().replaceWith($.clone(img));
			    regCropAvatar();
			},
			{
			    maxWidth: $crop_container.width(),
			    maxHeight: $crop_container.height()
			}
		);
    });

    // 默认照片/原照片 裁剪渲染
    regCropAvatar();

    // 保存头像按钮事件
    $('#upload_image_form').submit(function() {

        if (!$.trim($('#image_file', $(this)).val())) {
            showMsg("error", "请选择一张本地照片");
            return false;
        }

        var img = $('#my_avatar img')[0];
        var scale = Math.min(
            $crop_container.width() / img.naturalWidth,
            $crop_container.height() / img.naturalHeight
        );
        if (scale > 1) scale = 1;   // 若大于1表示原始图片没有缩小

        var c = jcrop_api.tellSelect();
        var rx = avatar_width / c.w;
        var ry = avatar_height / c.h;
        var rscale = parseFloat((scale * rx).toFixed(6));   // 小数点保留6位有效数

        $(this).ajaxSubmit({
            url: 'upload_avatar',
            data: {
                origin_width: img.naturalWidth,
                origin_height: img.naturalHeight,
                to_width: avatar_width,
                to_height: avatar_height,
                scale: rscale,          // 原始图片缩放的实际倍数,因为是等比缩放，所以x,y的缩放倍数是一样的
                x: c.x,                 // 选中区域的左上角X坐标, 请以该数据为依据
                y: c.y                  // 选中区域的左上角Y坐标, 请以该数据为依据
            },
            success: function(response) { // callback
                alert('success');
            }
        });

        return false;
    });

})