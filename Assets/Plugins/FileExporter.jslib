var FileExporterPlugin = {
 FileExporterCaptureClick: function() {
   if (!document.getElementById('FileExporter')) {
     var fileInput = document.createElement('input');
     fileInput.setAttribute('type', 'file');
     fileInput.setAttribute('id', 'FileExporter');
     fileInput.setAttribute('accept', '.json')
     fileInput.style.visibility = 'hidden';
     fileInput.onclick = function (event) {
       this.value = null;
     };
     fileInput.onchange = function (event) {
       SendMessage('ImportButton', 'FileSelectedEx', URL.createObjectURL(event.target.files[0]));
     }
     document.body.appendChild(fileInput);
   }

   var OpenFileDialog = function() {
     document.getElementById('FileExporter').click();
     canvas.removeEventListener('click', OpenFileDialog);
   };

   canvas.addEventListener('click', OpenFileDialog, false);
 }
};
mergeInto(LibraryManager.library, FileExporterPlugin);

mergeInto(LibraryManager.library, { 
  CopyWebGL: function(str) {
    var str = Pointer_stringify(str);
    var listener = function(e){
    e.clipboardData.setData("text/plain" , str);    
    e.preventDefault();
    document.removeEventListener("copy", listener);
    }
    document.addEventListener("copy" , listener);
    document.execCommand("copy");
  },
});