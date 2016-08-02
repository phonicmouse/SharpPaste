$("#confirmdeletepaste").click(function(){
    $("#title").val("");
    $("#body").val("");
});

$("#addpaste").click(function(){
    if($.trim($("#title").val()) && $.trim($("#body").val())){
        
    } else {
        $("#pasteerrormodal").modal("show");
    }
});
