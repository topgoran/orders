import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Article, ArticleDTO } from 'src/app/models/ArticleDTO';
import { AlertDialogComponent } from 'src/app/public/alert-dialog/alert-dialog.component';
import { ArticlesCrudService } from 'src/app/services/articles-crud.service';
import { DataSharingService } from 'src/app/services/data-sharing.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-add-update-article',
  templateUrl: './add-update-article.component.html',
  styleUrls: ['./add-update-article.component.css']
})
export class AddUpdateArticleComponent implements OnInit, OnDestroy {

  isAddMode!: boolean;

  articleId!: string;
  articleToEdit!: Article;
  subscription!: Subscription;

  addedArticleId!: string;

  loading$ = this.loader.loading$;


  constructor(private route: ActivatedRoute, private router: Router,  private articlesCrudService: ArticlesCrudService, private dataSharing: DataSharingService, private loader: LoadingService,
    public dialog: MatDialog) { }

  articleForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
    price: new FormControl(''),
    imageId: new FormControl(''),
    coverId: new FormControl('')
  });

  ngOnInit(): void {
    this.isAddMode = !this.route.snapshot.params['id'];

    if(!this.isAddMode){
      this.subscription = this.route.params.subscribe(params => {
        this.articleId = params['id'];
      });

      this.articlesCrudService.getArticle(this.articleId).subscribe(( data ) => {
        this.articleToEdit = data.data.article;

        this.articleForm.patchValue({
          name: this.articleToEdit.name,
          description: this.articleToEdit.description,
          price: this.articleToEdit.price,
          imageId: this.articleToEdit.imageId,
          coverId: this.articleToEdit.coverId
        })
      });
    }
  }

  ngOnDestroy(){
    if(!this.isAddMode){
      this.subscription.unsubscribe;
    }
  }

  onSubmit(){
    const newArticle = {
      name: this.articleForm.get("name")?.value,
      description: this.articleForm.get("description")?.value,
      price: Number(this.articleForm.get("price")?.value),
      imageId: Number(this.articleForm.get("imageId")?.value),
      coverId: Number(this.articleForm.get("coverId")?.value)
    }

    if(this.isAddMode){
      this.articlesCrudService.addNewArticle(newArticle).subscribe(({ data }) => {
        this.addedArticleId = data?.createArticle.id!;

        this.articlesCrudService.addArticleToMenu(this.dataSharing.menuId, this.addedArticleId).subscribe(( {data} ) => {
          let dialogRef = this.dialog.open(AlertDialogComponent, {
            data: {
              dialogTitle: "Adding article successful",
              dialogContent: "Go back"
            }
          })

          dialogRef.afterClosed().subscribe(result => {
            this.router.navigateByUrl('/admin/articles/list')
          })

        }, (error) => {
          this.dialog.open(AlertDialogComponent, {
            data: {
              dialogTitle: "Adding article failed",
              dialogContent: "Try again"
            }
          })
        })
      }, (error) => {
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Adding article failed",
            dialogContent: "Try again"
          }
        })
     })
    }else{
      this.articlesCrudService.updateArticle(this.articleId, newArticle).subscribe(( {data} ) => {
        let dialogRef = this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Editing article successful",
            dialogContent: "Go back"
          }
        })

        dialogRef.afterClosed().subscribe(result => {
          this.router.navigateByUrl('/admin/articles/list')
        })
      }, (error) => {
        this.dialog.open(AlertDialogComponent, {
          data: {
            dialogTitle: "Editing article failed",
            dialogContent: "Try again"
          }
        })
     });
    }
  };
}
