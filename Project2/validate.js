function Validate() {
    var id = document.getElementById("txtID").value;
    var name = document.getElementById("txtName").value;
    var address = document.getElementById("txtAddress").value;
    var phone = document.getElementById("txtPhone").value;
    var campus = document.getElementById("ddlCampus").value;

    if (id == "" || name == "" || address == "" || phone == "") {
        document.getElementById("lblDisplay").innerHTML = "Please fill out all the fields!";
        return false;
    }
    else if (campus == -1) {
        document.getElementById("lblDisplay").innerHTML = "Please select your campus!";
        return false;
    }
    else {
        //submit the form for server processing
        //document.getElementById("lblDisplay").innerHTML = "";
        document.getElementById("frmBookStore").submit();
        return true;
    }
}


