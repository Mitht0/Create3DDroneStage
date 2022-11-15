var FileImporterPlugin = {
 FileImporterCaptureClick: function() {
   if (!document.getElementById('FileImporter')) {
     var fileInput = document.createElement('input');
     fileInput.setAttribute('type', 'file');
     fileInput.setAttribute('id', 'FileImporter');
     fileInput.setAttribute('accept', '.json')
     fileInput.style.visibility = 'hidden';
     fileInput.onclick = function (event) {
       this.value = null;
     };
     fileInput.onchange = function (event) {
       SendMessage('ImportButton', 'FileSelected', URL.createObjectURL(event.target.files[0]));
     }
     document.body.appendChild(fileInput);
   }

   var OpenFileDialog = function() {
     document.getElementById('FileImporter').click();
     canvas.removeEventListener('click', OpenFileDialog);
   };

   canvas.addEventListener('click', OpenFileDialog, false);
 }
};
mergeInto(LibraryManager.library, FileImporterPlugin);