(function(){var n="0.1.34",a,e="undefined",t=25,r=parseInt(1e3/t),i=a,o={"function":!0,object:!0},s={DEBUG_MODE:!1,counterID:"3023",instanceID:"externalConf###Instanceid"},u=function(n){return typeof n!==e},c="HISTATS_CANVAS_DEBUG_ON";s.DEBUG_MODE=u(window[c])&&1==window[c];var f=function(){return s.instanceID},l="_HistatsCounterGraphics_",d,h=function(){return l+s.counterID},v=function(n){return!("string"!=typeof n||""==n)},m=function(){try{s.DEBUG_MODE&&u(console)&&console.log.apply(this,arguments)}catch(n){}},b=function(e,t){var o=e||{};try{var c=function(n){var a="autostart";return"undefined"!=typeof n[a]&&n[a]===!0},f={ANIMATION_RUNNING_STATUS:!0,ANIMATION_STARTED:!1,AUTOSTART:c(o),_STOPPED:!1,INSTANCE_ID:"-"+parseInt(1e4*Math.random())},l=function(){return f.INSTANCE_ID},v=100,b=1,g=function(){return t.document},A=function(n){return u(n)&&!!g().getElementById(n)},p=function(n){i=t.setTimeout(n,r)},w=t.requestAnimationFrame||t.webkitRequestAnimationFrame||t.mozRequestAnimationFrame||t.msRequestAnimationFrame||t.oRequestAnimationFrame||p,C=t["Date"]||{},B=function(n,a){for(var e in n)a.hasOwnProperty(e)&&(a[e]=n[e])};o.getInstanceID=l;var I=h();o.IS_HISTATS_CANVAS=!0,o.globalObjectName=I,o.$window=t;var x=function(n){return A(n)?g().getElementById(n):a},T={w:0,h:0,yBase:0,xBase:0,hasShadow:!1,hasLabel:!1,shadowOffsetX:2,shadowOffsetY:2,shadowBlur:1,doMouseOverOut:1},y={msLastFrameDrawn:0,msPerFrame:r,frameCounter:0,isInAnimationTransition:!1,animation_duration_inFrames:20,waitframesBetweenTwoAnimations:80,framesBetweenTwoAnimations:100,currentLoopFrame:0,autoTriggerTextChange_onFrame:a,customization:{}},S={domCanvasObject:null,canvas2dContext:null,canvasProperties:T},O=function(){var n={},e=n.hasOwnProperty,t=0,r=0,i={blockMessages:!1,recordMessages:!1,messageLog:[],printMessages:!1,messagePassedCount:0,subscribersCount:0,topicsCount:0,_topics:n},o=function(a){return e.call(n,a)},s=function(a){return i.printMessages&&console.log(l(),"addTopic",a),r++,i.topicsCount++,r>50&&m(l(),"Lot of topics registered!",a),n[a]=[]},u=function(a){return n[a]},c=function(a,e,r){i.printMessages&&console.log(l(),"subscribe",a,e,r),i.recordMessages&&i.messageLog.push(["subscribe",a,e,r]),r=r||v,o(a)||s(a);var c=u(a).push({callback:e,priority:e})-1;return t++,i.subscribersCount++,t>50&&m(l(),"Lot of topics registered!",a),{remove:function(){delete n[a][c]}}},f=function(n,a){var e="no-topic-found";n!=e&&d(e,{topic:n,info:a})},d=function(e,t){return i.messagePassedCount++,i.printMessages&&console.log(l(),"publish",e,t),i.recordMessages&&i.messageLog.push(["publish",e,t]),i.blockMessages?void 0:o(e)?(n[e].slice().sort(function(n,a){return n.priority-a.priority}).forEach(function(n){n.callback(t!=a?t:{})}),void 0):(f(e,t),void 0)},h=function(n,a){w(function(){d(n,a)})};return{subscribe:c,publish:d,publishAsync:h,debugObj:i}}(),E=function(){return s.counterID},N=function(){var n="siteId";return o[n]=o[n]||0},_=function(){var n="main_div_name";return o[n]||"histats_counter_"+N()+"_"+E()},P=[],D=function(){return d=_(),d},F=function(){return D()+"_canvas"},M=function(){return"http://www.histats.com/viewstats/?sid="+N()+"&ccid="+E()},k=function(){t.location=M()},R=function(){if(1==S.canvasProperties.doMouseOverOut){var n=K().canvasProperties;n.yBase=2,n.xBase=2,n.shadowOffsetX=0,n.shadowOffsetY=0}K().domCanvasObject.style.cursor="pointer"},U=function(){if(1==S.canvasProperties.doMouseOverOut){var n=K().canvasProperties;n.yBase=0,n.xBase=0,n.shadowOffsetX=2,n.shadowOffsetY=2}},V=function(){var n=K(),a=n.canvasProperties,e=n.canvas2dContext;e.shadowOffsetX=a.shadowOffsetX,e.shadowOffsetY=a.shadowOffsetY,e.shadowBlur=a.shadowBlur,e.shadowColor="rgba(0,0,0,0.2)"},G=function(){return x(D())},Y=function(){var n=!!G();return n},H=function(){try{if(!Y())return O.publish("error",{msg:"validateDomcontainer not found"}),void 0;var n=G(),a=K().canvasProperties,e='<canvas id="'+F()+'" width="'+a.w+'" height="'+a.h+'" ></canvas>',r='<a href="'+M()+'" target="_blank">'+e+"</a>";n.innerHTML=r,K().domCanvasObject=x(F());var i=K().domCanvasObject;K().canvas2dContext=i.getContext("2d"),"addEventListener"in t?(i.addEventListener("mouseover",function(){R()}),i.addEventListener("mouseout",function(){U()})):i.onclick=function(){k()}}catch(o){m(l(),"drawCanvas",o)}},L=function(){try{if(f.ANIMATION_STARTED)return;if(f._STOPPED)return;O.publish("draw-callback-requested-reconfiguration",{}),O.publish("starting_pre",{context:o}),f.ANIMATION_STARTED=!0,O.publish("started",{context:o}),O.publish("drawcanvas_pre",{context:o}),H(),O.publish("drawcanvas_post",{context:o}),z(),O.publish("animationLoop_started",{context:o})}catch(n){m(l(),"startNow",n,n.message)}},j=function(n,a,e){a.addEventListener?a.addEventListener(n,e,!1):a.attachEvent?a.attachEvent("on"+n,e):a[n]=e},q=function(){try{O.publish("appendedStart",{context:o,type:"animFrame"}),w(L)}catch(n){m(l(),"startAsap",n.message,n)}},X=function(n,a){P.push({name:n,callback:a})},Z=function(){},J=function(){P.forEach(function(n){n.callback(o.getCanvas2dContext(),y,K())})},Q=function(){u(i)&&t.clearTimeout(i)},z=function(){f._STOPPED||w(function(){an(J),f.ANIMATION_RUNNING_STATUS&&z()})};O.subscribe("setAnimationProperties",function(n){B(n,y)}),O.subscribe("draw-callback-publish-reconfiguration",function(n){try{n.canvasCallbacks.forEach(function(n){P.push({name:n.name,callback:n.cb,priority:n.priority})}),P=P.slice().sort(function(n,a){return n.priority-a.priority})}catch(a){m(l(),"animationLoop",a.message,a)}}),O.subscribe("configuration-changed",function(n){P=[],O.publish("draw-callback-requested-reconfiguration",{})});var W=function(n){var a=n!=f.ANIMATION_RUNNING_STATUS;return a&&(0==f.ANIMATION_RUNNING_STATUS&&1==n,1==f.ANIMATION_RUNNING_STATUS&&0==n&&Q(),f.ANIMATION_RUNNING_STATUS=n),a},K=function(){return S},$=function(){var n=!1;0==y.frameCounter&&O.publish("FIRST-FRAME",{});var a=C.now(),e=a-y.msLastFrameDrawn;if(e>y.msPerFrame){var t=e%y.msPerFrame;y.msLastFrameDrawn=a-t,n=!0}return n},nn=function(){if(!(y.animation_duration_inFrames<1)){var n=y.animation_duration_inFrames+y.waitframesBetweenTwoAnimations;y.currentLoopFrame=y.frameCounter%n;var a=0==y.currentLoopFrame,e=y.currentLoopFrame>=y.animation_duration_inFrames;a&&(y.isInAnimationTransition=!0,O.publish("drawing-triggered-animation-start",y)),e&&y.isInAnimationTransition&&(y.isInAnimationTransition=!1,O.publish("drawing-triggered-animation-end",y))}},an=function(n){var a=$();a&&(y.frameCounter++,nn(),n())},en=function(n){return n(o.getCanvas2dContext())},tn=function(){var n=17,a=2,e=1,t=K().canvasProperties,r=0;t.hasShadow&&(r=r+a+e),t.hasLabel&&(t.h=t.h+n),t.w=t.w+r,t.h=t.h+r},rn=function(n){B(n,K().canvasProperties),tn()};O.subscribe("setCanvasProperties",rn,10);var on=function(){o.onCanvas2dContext(function(n){var a=K().canvasProperties;n.clearRect(0,0,a.w,a.h),a.hasShadow&&V()})};O.subscribe("clear-canvas-rectangle",on,10);var sn=function(n,a){K().hasShadow&&(n.shadowOffsetX=0,n.shadowOffsetY=0,n.shadowBlur=0,n.shadowColor="transparent")},un=function(n,e){e.autoTriggerTextChange_onFrame!==a&&e.currentLoopFrame==e.autoTriggerTextChange_onFrame&&O.publish("drawing-change-text",{})},cn=function(n){O.publish("draw-callback-publish-reconfiguration",{canvasCallbacks:[{cb:sn,priority:14,name:"stopApplyingShadowOnCanvas"},{cb:un,priority:5,name:"autoUpdateText"}]})};O.subscribe("draw-callback-requested-reconfiguration",cn,15),o.__CODE_VERSION=n,o.getCanvasObject=K,o.getCanvas2dContext=function(){return K().canvas2dContext},o.onCanvas2dContext=en,o.getXYCanvas=function(){return{x:K().canvasProperties.xBase,y:K().canvasProperties.yBase}},o.addDrawCallback=X,o.getCanvasProperties=function(){return K().canvasProperties},o.setCanvasProperties=function(n){for(var a in n)n.hasOwnProperty(a)&&(S.canvasProperties[a]=n[a])},o.updateCanvasProperties=function(n){o.setCanvasProperties(n(K().canvasProperties))},o.getAnimationFrames=function(){return y.frameCounter},o.getAnimationControl=function(){return y},o.setAnimationControl=function(n){for(var a in n)n.hasOwnProperty(a)&&(y[a]=n[a])},o.start=q,o.changeRunningStatus=W,o.getRunningStatus=function(){return f.ANIMATION_RUNNING_STATUS},o.eventBus=O,o.getDebugMode=function(){return s.DEBUG_MODE},function(){var n=this;n.IS_HISTATS_CANVAS||(n={});var a=n.bars={},e=!1,t=3,r=1,i=0,o=[2,5,10];n.eventBus.subscribe("set-bars-params",function(a){f(a),n.eventBus.publish("configuration-changed",{})});var s=[],u={xBase:5,yBase:13,hMin:2,hMax:10,w:4,barsColours:[["#3e8bfd","#2572e4"],["#feb23f","#dc901d"],["#d83f3f","#b41b1b"]],parent:n},c=function(){return u},f=function(n){for(var a in n)n.hasOwnProperty(a)&&(u[a]=n[a])},l=function(n){e=!0;for(var a=0;t>a;a++)n.push({x:a*(u.w+1),y:0,width:u.w,height:o[a],animateDirection:r,gradient:null,gradientStart:u.barsColours[a][0],gradientEnd:u.barsColours[a][1]})},d=function(a){var e=.5,t=a.height,o=n.getXYCanvas();a.animateDirection==r&&t>=u.hMax?a.animateDirection=i:a.animateDirection==i&&t<=u.hMin&&(a.animateDirection=r),t+=e*(a.animateDirection==r?1:-1),a.y=u.yBase-t+o.y,a.height=t},h=function(a){return function(e){var t=n.getXYCanvas();e.shadowOffsetX=0,e.shadowOffsetY=0,e.shadowBlur=0,e.beginPath(),e.fillStyle=b(a,e),e.fillRect(t.x+u.xBase+a.x,a.y,a.width,a.height)}},v=function(a){n.eventBus.publish("draw-callback-publish-reconfiguration",{canvasCallbacks:[{cb:m,priority:20,name:"bars_draw"}]})};n.eventBus.subscribe("draw-callback-requested-reconfiguration",v,11);var m=function(){e||l(s);for(var a in s)if(s.hasOwnProperty(a)){var t=s[a];d(t),n.onCanvas2dContext(h(t))}},b=function(a,e){var t=n.getXYCanvas(),r=u.xBase,i=e.createLinearGradient(r+a.x+t.x,a.y,r+a.x+a.width,a.height+a.y);return i.addColorStop(0,a.gradientStart),i.addColorStop(1,a.gradientEnd),i};a.getBoxProperties=c,a.setBoxProperties=f,a.transformBarsColour=function(n){barsColours=n(u.barsColours)},a.draw=m}.call(o),function(){var n=this;n.IS_HISTATS_CANVAS||(n={});var e=n.statsText={},t={xBase:0,yBase:0},r=function(){return t},i=function(){var a=n.getXYCanvas();return t.xBase=a.x,t.yBase=a.y,t},o=[],s={stats_values:[],indexStatToShow:0,drawValueCallback:a,drawValueCallbackWithValue:a,drawMetricCallback:a},u=25,c=0,f=function(){return c%u==1},l=function(n){o=n};n.eventBus.subscribe("set-textbox-style",function(a){o=a,n.eventBus.publish("configuration-changed",{})}),n.eventBus.subscribe("canvas-drawValueFunction",function(n){"undefined"!=typeof n["transformationFunction"]&&(s.drawValueCallback=n["transformationFunction"])});function d(n,a,e,t){n=(n+"").replace(/[^0-9+\-Ee.]/g,"");var r=isFinite(+n)?+n:0,i=isFinite(+a)?Math.abs(a):0,o="undefined"==typeof t?",":t,s="undefined"==typeof e?".":e,u="",c=function(n,a){var e=Math.pow(10,a);return""+(Math.round(n*e)/e).toFixed(a)};return u=(i?c(r,i):""+Math.round(r)).split("."),u[0].length>3&&(u[0]=u[0].replace(/\B(?=(?:\d{3})+(?!\d))/g,o)),(u[1]||"").length<i&&(u[1]=u[1]||"",u[1]+=new Array(i-u[1].length+1).join("0")),u.join(s)}var h=function(e){if(s.stats_values=e,s.drawValueCallback!=a){var t=e[0].value;s.drawValueCallbackWithValue=s.drawValueCallback(t)}n.eventBus.publish("configuration-changed",{})},v=function(){return s.stats_values},m=function(n){if(n===s.stats_values)return!1;if(typeof n==typeof[])for(var a in n)if(n.hasOwnProperty(a)&&typeof n[a]!=typeof{})return!1;return!0},b=function(){return n.globalObjectName+"_setValues"},g=function(){if(f()){var a=b();if("undefined"!=typeof n.$window&&"undefined"!=typeof n.$window[a]){var e=n.$window[a];m(e)&&h(e)}}},A=function(n){return(""+n).match(/^\s*[0-9]+\s*$/)?d(n,0,""," "):n},p=function(a,e){return function(t){t.shadowColor="transparent",t.font=a.name.font,t.textAlign=a.name.align,t.fillStyle=a.name.color,t.fillText(e.name,a.name.x+r().xBase,a.name.y+r().yBase),t.font=a.value.font,t.textAlign=a.value.align,t.fillStyle=a.value.color;var i=e.value;try{i=A(e.value)}catch(o){n.debug(o)}t.fillText(i,a.value.x+r().xBase,a.value.y+r().yBase)}},w=function(){s.indexStatToShow+=o.length,s.indexStatToShow>=s.stats_values.length&&(s.indexStatToShow=0)},C=!1;n.eventBus.subscribe("draw-hideText",function(n){C=!0},11),n.eventBus.subscribe("draw-unHideText",function(n){C=!1},11);var B=function(n){if(!C){var a,e,t=s.indexStatToShow,r=v(),i=r.length;r.length>o.length&&(i=o.length);for(var u=0;i>u&&(t>=r.length&&(t=0),r[t]);u++)a=o[u],e=r[t],p(a,e)(n),t++}},I=function(n,e){return c++,g(),i(),s.drawValueCallbackWithValue!=a?(s.drawValueCallbackWithValue(n),void 0):(B(n),void 0)},x=function(a){n.eventBus.publish("draw-callback-publish-reconfiguration",{canvasCallbacks:[{cb:I,priority:15,name:"show_stats_draw"}]})};n.eventBus.subscribe("draw-callback-requested-reconfiguration",x,11);var T=n.eventBus.subscribe("drawing-change-text",w,10);e.draw=I,e.setBoxes=l,e.setValues=h}.call(o),function(){var n=this;n.IS_HISTATS_CANVAS||(n={});var e={main:"",source:a,loaded:!1};e.main="data:image/png;base64,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";var t=function(a){var t=e.source=new Image;t.onload=function(){e.loaded=!0,n.eventBus.publish("background-image-loaded",e),n.eventBus.publish("configuration-changed",{})},t.src=e.main};n.eventBus.subscribe("FIRST-FRAME",t,5),n.image_base64_src=e}.call(o),function(){var n=this;n.IS_HISTATS_CANVAS||(n={});var e=n.counter={};e.ID="3023",e.properties={w:128,h:78,hasShadow:!0};var t=!1,r={backgroundImageObject:a},i={xBase:5,yBase:14,barsColours:[["#999999","#999999"],["#999999","#999999"],["#999999","#999999"]]},o={animation_duration_inFrames:20,autoTriggerTextChange_onFrame:10,waitframesBetweenTwoAnimations:110},s=[{name:{x:5,y:33,align:"left",color:"#ffffff",font:"11px Arial"},value:{x:122,y:33,align:"right",color:"#ffffff",font:"11px Arial"}},{name:{x:5,y:53,align:"left",color:"#ffffff",font:"11px Arial"},value:{x:122,y:53,align:"right",color:"#ffffff",font:"11px Arial"}},{name:{x:5,y:72,align:"left",color:"#ffffff",font:"11px Arial"},value:{x:122,y:72,align:"right",color:"#ffffff",font:"11px Arial"}}];n.eventBus.publish("set-textbox-style",s),n.eventBus.publish("setCanvasProperties",e.properties),n.eventBus.publish("setAnimationProperties",o),n.eventBus.publish("set-bars-params",i);var u={alpha:{movementsPerFrame:1,min:0,max:100,cur:0}},c=function(n){var a=u;a.alpha.movementsPerFrame=(u.alpha.max-u.alpha.min)/(o.animation_duration_inFrames/2)};c(o.animation_duration_inFrames);var f=function(n){var a=n,e=0;if(!a.isInAnimationTransition)return e;var t=a.currentLoopFrame<a.animation_duration_inFrames/2,r=!t;return t&&(e=1),r&&(e=-1),e},l=function(n,a){var e=u,t=f(a);0==t?e.alpha.cur=e.alpha.min:d(n,t)},d=function(a,e){var t=u,i=n.getXYCanvas(),o=t.alpha.movementsPerFrame*e;t.alpha.cur=Math.max(Math.min(t.alpha.cur+o,t.alpha.max),t.alpha.min),a.save(),a.globalAlpha=t.alpha.cur/100,a.drawImage(r.backgroundImageObject.source,i.x,i.y),a.restore()},h=function(a,e){n.eventBus.publish("clear-canvas-rectangle",{});var t=n.getXYCanvas();a.drawImage(r.backgroundImageObject.source,t.x,t.y)},v=function(e){r.backgroundImageObject!=a&&n.eventBus.publish("draw-callback-publish-reconfiguration",{canvasCallbacks:[{cb:h,priority:10,name:"drawBackground"},{cb:l,priority:19,name:"drawAnimation"}]})};return n.eventBus.subscribe("draw-callback-requested-reconfiguration",v,13),n.eventBus.subscribe("background-image-loaded",function(n){r.backgroundImageObject=n},13),n}.call(o),f.AUTOSTART&&o.start()}catch(fn){}return o},g="base.js",A=window,p="_DEBUG_HISTATSCANVAS_RETURN_BUILDER";_value_RETURN_BUILDER=u(window[p])&&window[p]===!0,window[h()]=b,window["histats_canvascounters_"+g]=b}).call(this);