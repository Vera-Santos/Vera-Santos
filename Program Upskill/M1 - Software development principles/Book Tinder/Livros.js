$( document ).ready(function() {
    
    class Book{
        constructor(id, title, description, authors, img){
            this.id = id;
            this.title = title;
            this.description = description; 
            this.authors = authors; 
            this.img = img;
        }
        // Métodos
        getAuthors(){
            let autoresStr = "";
            for(const author of this.authors){
                autoresStr = autoresStr + author + ", ";
            }
            return autoresStr; 
        }

        getImage(){
            return this.img;
        }
    }
    

    $.getJSON("https://www.googleapis.com/books/v1/volumes?q=harry+potter", function(response){
        let books = [];
        
        for(const item of response.items){
            let b = new Book(item.id, item.volumeInfo.title, item.volumeInfo.description, item.volumeInfo.authors, item.volumeInfo.imageLinks.thumbnail);
            books.push(b);
        }

        for(const book of books){
            $("#content").append(`<img src=${book.getImage()}>`);
            $("#content").append(`<h5>${book.title}</h1>`);
            $("#content").append(`<h4>${book.getAuthors()}<h4>`);
            $("#content").append(`<p>${book.description}</p>`);
        }
    });
});