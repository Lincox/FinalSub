/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */



CKEDITOR.editorConfig = function (config) {
    //Thêm plugin insert youtube link
    config.extraPlugins = 'youtube';
    //Make video youtube responsive
    config.youtube_responsive = true;
    //Show related videos
    config.youtube_related = true;

    config.height = '500px';

    //Customize toolbar by removing button
    config.removeButtons = 'Preview,Source,Save,NewPage,DocProps,Templates,document,Cut,Copy,Paste,PasteText,PasteFromWord,Undo,Redo,Find,Replace,SelectAll,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,NumberedList,BulletedList,Outdent,Indent,Blockquote,CreateDiv,BidiLtr,BidiRtl,CreatePlaceholder,InsertPre,UIColor,Maximize,ShowBlocks,About,Print,Underline,JustifyCenter';

    //Chỉ ra ngôn ngữ
    //config.language = 'vi';
    config.language = 'en';

    //Cấu hình đường dẫn các loại tệp tin khi finder
    config.filebrowserBrowserUrl = "/Content/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Content/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashUrl = "/Content/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File";
    config.filebrowserImageUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    config.filebrowserFlashUploadUrl = "/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    CKFinder.setupCKEditor(null, "/Content/ckfinder/");
};


//Ghi chú hướng dẫn

//1. Cách để tạo 1 toolbar ckeditor mới hoàn toàn
/*config.toolbar = 'MyToolbar';

    config.toolbar_MyToolbar =
        [
            //{ name: 'document', items: ['NewPage', 'Preview'] },
            //{ name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
            //{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
            //{
            //    name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'
            //        , 'Iframe']
            //},
            {
                name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'Iframe', 'Youtube']
            }
            //'/',
            { name: 'styles', items: ['Styles', 'Format'] },
            { name: 'basicstyles', items: ['Bold', 'Italic', 'Strike', '-', 'RemoveFormat'] },
            { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote'] },
            { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
            //{ name: 'tools', items: ['Maximize', '-', 'About'] }
        ];*/

//2. Thêm các tính năng cho youtube plugin
/*CKEDITOR.plugins.addExternal('youtube', '/Content/node_modules/ckeditor-youtube-plugin/youtube/');

config.extraPlugins = 'youtube';
//Video width:
config.youtube_width = '640'
//Video height:
config.youtube_height = '480';
//Make responsive (ignore width and height, fit to width):
config.youtube_responsive = true;
//Show related videos:
config.youtube_related = true;
//Use old embed code:
config.youtube_older = false;
//Enable privacy-enhanced mode:
config.youtube_privacy = false;
//Start video automatically:
config.youtube_autoplay = false;
//Showplayer controls:
config.youtube_controls = true; */

