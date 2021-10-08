
class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    appendTableCellsToRow(row, cells) {
        for (let index = 0; index < cells.length; ++index) {
            let cellElement = document.createElement("td");
            let cellText = document.createTextNode(cells[index]);
            cellElement.appendChild(cellText);
            row.appendChild(cellElement);
        }
    }

    fillContext() {
        fetch(this.dataOrigin)
        .then(response => {
            return response.json();
        })
        .then(data => {
            let table = document.createElement("table");
            let tableBody = document.createElement("tbody");
            let headerRow = document.createElement("tr");
            this.appendTableCellsToRow(headerRow, ["Id", "Name", "Quantity", "Price"]);
            tableBody.appendChild(headerRow);
            
            for (const object of data) {
                let row = document.createElement("tr");
                let cells = []
                for (const key in object) {
                    cells.push(`${object[key]}`);
                }
                this.appendTableCellsToRow(row, cells);
                tableBody.append(row);
            }
            table.setAttribute("id", "productsTable");
            table.appendChild(tableBody);
            this.context.appendChild(table);

            $(document).ready(function () {
                $('#productsTable').DataTable();
            });
        })
        .catch(error => {
            console.log(error);
        })
    }
}