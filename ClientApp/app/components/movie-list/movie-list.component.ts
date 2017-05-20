import { MovieService } from './../../services/movie.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  private movies : any[];
  constructor(private movieService : MovieService) { }

  ngOnInit() {
    this.movieService.getMovies()
      .subscribe(movies => {
        this.movies = movies;
      });
  }

}
