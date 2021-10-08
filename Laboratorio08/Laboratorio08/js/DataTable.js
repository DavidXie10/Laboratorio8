
class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    fillContext() {
        fetch(this.dataOrigin)
        .then(response => {
            return response.json();
        })
        .then(data => {
            let htmlContent = '';
            let row = '';
            for (const object of data) {
                for (const key in object) {
                    row += `${object[key]}`
                }
                htmlContent += `<p>${row}</p><br/>`;
                row = '';
            }
            this.context.innerHTML = htmlContent;
        })
        .catch(error => {
            console.log(error);
        })
    }
}