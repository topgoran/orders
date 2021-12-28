import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatSelectChange } from '@angular/material/select';
import { Router } from '@angular/router';
import { Article } from 'src/app/models/ArticleDTO';
import { Menu, MenusDTO } from 'src/app/models/MenusDTO';
import { SelectMenu } from 'src/app/models/SelectMenu';
import { AlertDialogComponent } from 'src/app/public/alert-dialog/alert-dialog.component';
import { ArticlesCrudService } from 'src/app/services/articles-crud.service';
import { DataSharingService } from 'src/app/services/data-sharing.service';
import { MenusCrudService } from 'src/app/services/menus-crud.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-articles-table',
  templateUrl: './articles-table.component.html',
  styleUrls: ['./articles-table.component.css']
})
export class ArticlesTableComponent implements OnInit {

  loading = true;
  currentMenuId!: string;
  menus!: Menu[];
  articles: Article[] = [];
  allArticles: Article[] = [];

  selectMenus: SelectMenu[] = [];


  columnsToDisplay = ['name', 'description', 'price', 'image', 'editColumn', 'deleteColumn'];

  postPerPage = 50;
  pageNumber = 1;
  totalItems!: number;

  filter: string = "";

  selectedMenu!: string;

  loading$ = this.loader.loading$;


  constructor(private menusCrudService: MenusCrudService, private router: Router, private dataSharing: DataSharingService, private loader: LoadingService,
    private articlesCrudService: ArticlesCrudService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.menusCrudService.getMenus().subscribe(({ data, loading }) => {
      this.loading = loading;
      this.menus = data.menus;

      for(let i = 0; i < this.menus.length; i++){
        let selectMenu = { value: this.menus[i].id, viewValue: this.menus[i].name }
        this.selectMenus.push(selectMenu)
      }

      this.selectedMenu = data.menus[0].id;

      let tempArticles = [];

      for(let i = 0; i < this.menus[0].menuitems.length; i++){
        tempArticles.push(this.menus[0].menuitems[i].articles[0])
      }

      this.articles = tempArticles;
      this.allArticles = tempArticles;
    });
  }

  deleteSelectedArticle(id: string){
    this.articlesCrudService.deleteArticle(id).subscribe(({ data }) => {
      console.log(data?.deleteArticle)
      if(data?.deleteArticle){
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Article deleted successfully",
            dialogContent: "Finish"
          }
        })
      }else{
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Article deletion failed",
            dialogContent: "Try again"
          }
        })
      }
    }, (error) => {
      this.dialog.open(AlertDialogComponent, {
        data: {
          dialogTitle: "Article deletion failed",
          dialogContent: "Try again"
        }
      })
    });
  }

  editSelectedArticle(id: string){
    this.dataSharing.menuId = this.selectedMenu;
    this.router.navigateByUrl('admin/articles/update/' + id);
  }

  addNewArticle(){
    this.dataSharing.menuId = this.selectedMenu;
    this.router.navigateByUrl('admin/articles/add');
  }

  onPaginate(pageEvent: PageEvent) {
    this.postPerPage = pageEvent.pageSize;
    this.pageNumber = pageEvent.pageIndex + 1;
  }

  onMenuChanged(event: MatSelectChange){
    this.menusCrudService.getMenu(event.value).subscribe(({ data, loading }) => {
      this.loading = loading;
      this.currentMenuId = data.menu.id;
      this.articles = data.menu.menuitems[0].articles;

      this.selectedMenu = data.menu.id;
      let tempArticles = [];

      for(let i = 0; i < data.menu.menuitems.length; i++){
        tempArticles.push(data.menu.menuitems[i].articles[0])
      }

      this.articles = [];
      this.articles = tempArticles;
    });
  }
}
