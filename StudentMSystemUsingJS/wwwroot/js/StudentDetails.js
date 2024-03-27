document.getElementById('searchInput').addEventListener('input', function () {
    var searchValue = this.value.trim().toLowerCase();
    var rows = document.querySelectorAll('#studentTable tbody tr');

    rows.forEach(function (row) {
        var cells = row.getElementsByTagName('td');
        var matchFound = false;

        // Check only FirstName (0), LastName (1), and Age (3) columns
        var columnsToSearch = [0, 1, 3];

        for (var j = 0; j < columnsToSearch.length; j++) {
            var columnIndex = columnsToSearch[j];
            var cellText = cells[columnIndex].textContent.toLowerCase();

            if (cellText.includes(searchValue)) {
                matchFound = true;
                break;
            }
        }

        row.style.display = matchFound ? '' : 'none';
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const table = document.getElementById("studentTable");
    const rows = Array.from(table.getElementsByTagName("tr")).slice(1);
    let selectedRow = rows[0];

    // Highlight the default selected row
    selectedRow.classList.add("selected-row");

    // Sortable Table Header
    document.querySelectorAll('.sortable').forEach(header => {
        header.addEventListener('click', () => {
            const column = header.getAttribute('data-sort');
            const isAscending = header.classList.toggle('asc');
            const sortedRows = sortTable(column, isAscending);
            reRenderTable(sortedRows);
        });
    });

    // Click event for table rows
    rows.forEach(row => {
        row.addEventListener('click', () => {
            selectedRow.classList.remove("selected-row");
            selectedRow = row;
            selectedRow.classList.add("selected-row");
        });

        row.addEventListener('dblclick', () => {
            // Open the record for edit (You can add your logic here)
            // Open the record for edit
            const studentId = row.dataset.studentId;
            openAddEdit(studentId);
        });
    });

    // Function to sort the table based on a column
    function sortTable(column, ascending) {
        const index = headerIndex(column);
        const sortedRows = rows.sort((a, b) => {
            const aValue = a.children[index].textContent;
            const bValue = b.children[index].textContent;
            return ascending ? aValue.localeCompare(bValue) : bValue.localeCompare(aValue);
        });
        return sortedRows;
    }

    // Function to re-render the sorted table
    function reRenderTable(sortedRows) {
        const tbody = table.querySelector('tbody');
        sortedRows.forEach(row => {
            tbody.appendChild(row);
        });
    }

    // Helper function to get the index of the table header
    function headerIndex(column) {
        const headers = Array.from(table.querySelectorAll('th'));
        return headers.findIndex(header => header.dataset.sort === column);
    }
    function openAddEdit(studentId) {
        window.location.href = `/AddEdit?id=${studentId}`;
    }
});
