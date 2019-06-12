function ajax(url, funSucc, funFaild){
    //1.����ajax����
    var ajaxObj = null;
    if(window.XMLHttpRequest){
        ajaxObj = new XMLHttpRequest();
    }else if(window.ActiveObject){
        ajaxObj = new ActiveXObject("Microsoft.XMLHTTP");
    }else{
        throw new Error('no ajax object available.')
}
      
    //2.���ӷ�����  
    ajaxObj.open('GET', URL, true);//open(����, url, �Ƿ��첽)
      
    //3.��������  
    ajaxObj.send();
      
    //4.���շ���
    ajaxObj.onreadystatechange = function(){  //OnReadyStateChange�¼�
        if(ajaxObj.readyState == 4){  //4Ϊ���
            if(ajaxObj.status == 200){    //200Ϊ�ɹ�
                funSucc(ajaxObj.responseText) 
            }else{
                if(funFaild){
                    funFaild();
                }
            }
        }
    };
}