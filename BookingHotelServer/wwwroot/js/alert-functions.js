window.SwAlert = (type, message) => {
    if (type === 'success') {
        Swal.fire(
            'Success Message',
            message,
            'success'
        );
    }
    if (type === 'error') {
        Swal.fire(
            'Error Message',
            message,
            'error'
        );
    }
}