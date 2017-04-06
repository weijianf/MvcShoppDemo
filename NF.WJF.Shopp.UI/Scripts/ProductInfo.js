window.onload = function () {

    magnifier();

    function magnifier() {
        //获取DOM
        var migni = document.getElementById('magnifier'); //最外层DIV

        var sLayer = migni.getElementsByTagName('div')[0]; //左边小的图片容器
        var bLayer = migni.getElementsByTagName('div')[1]; //右边大的图片容器

        var flt = migni.getElementsByTagName('span')[0]; // 跟随鼠标移动的浮动层

        var smallImg = sLayer.getElementsByTagName('img')[0]; //800*800的大图
        var bigImg = bLayer.getElementsByTagName('img')[0]; //800*800的大图



        //注册事件
        migni.onmouseover = function (e) {

            // 休正事件对象
            var evt = fixEvent(e);

            //当鼠标在migni里快速的移动，鼠标会在flt和smallImg中快速切换，不断触发事件和事件冒泡间接的触发事件。需要屏蔽掉。
            if (evt.relatedTarget == flt || evt.relatedTarget == smallImg) return false;

            flt.style.display = 'block';

            bLayer.style.display = 'block';
        }

        migni.onmouseout = function (e) {


            var evt = fixEvent(e);

            if (evt.relatedTarget == flt || evt.relatedTarget == smallImg) return false;

            flt.style.display = 'none';

            bLayer.style.display = 'none';
        }


        migni.onmousemove = function (e) { //事件必须绑定在外层上，否则鼠标在 flt上移动，事件不会冒泡到migni上

            var evt = fixEvent(e);
            var l = evt.pageX - migni.offsetLeft - flt.offsetWidth / 2;
            var t = evt.pageY - migni.offsetTop - flt.offsetHeight / 2;


            // 给 flt设置活动范围
            if (l < 0) {
                l = 0;
            } else if (l > migni.offsetWidth - flt.offsetWidth) {
                l = migni.offsetWidth - flt.offsetWidth;
            }

            if (t < 0) {
                t = 0;
            } else if (t > migni.offsetHeight - flt.offsetHeight) {
                t = migni.offsetHeight - flt.offsetHeight;
            }

            //设置浮动层的位置
            flt.style.left = l + 'px';
            flt.style.top = t + 'px';
            //console.log(e.pageX);


            //设置大图的位置。

            bigImg.style.left = -(l / smallImg.offsetWidth * bigImg.offsetWidth) + 'px';
            bigImg.style.top = -(t / smallImg.offsetHeight * bigImg.offsetHeight) + 'px'

        }

        //修正事件对象，处理兼容性
        function fixEvent(evt) {

            var e = evt || window.event;

            if (!e.target) {  //IE

                if (e.type == 'mouseover') {
                    e.relatedTarget = e.fromElement;
                } else if (e.type == 'mouseout') {
                    e.relatedTarget = e.toElement;
                }

                e.pageX = document.documentElement.scrollLeft + e.clientX;
                e.pageY = document.documentElement.scrollTop + e.clientY;
            }



            return e;

        }

    }
}