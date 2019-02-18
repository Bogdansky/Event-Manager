$(function () {
    $("#add_field").click(function () {
        let index = document.getElementsByClassName("additional").length;
        let row = document.createElement("tr");
        row.appendChild(addField(index, "title"));
        row.appendChild(addField(index, "value"));
        row.className = "additional";
        document.getElementById("params").appendChild(row);
    });

    $("#remove_last_field").click(function () {
        removeField();
    });
})

function addField(index, type) {
    let cell = document.createElement("td");
    let input = document.createElement("input");
    input.type = "text";
    input.name = `AdditionalInfo[${index}].${type}`;
    input.setAttribute("required", "");
    cell.appendChild(input);
    return cell;
}

function removeField() {
    let additional = document.getElementsByClassName("additional");
    additional[additional.length - 1].remove();
}