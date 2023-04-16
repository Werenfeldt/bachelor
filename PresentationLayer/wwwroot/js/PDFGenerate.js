function DownloadPdf(filname, byteBase64) {
    var link = document.createElement('a');
    link.download = filname;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}