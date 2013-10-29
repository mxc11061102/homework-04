#include <cstdio>
#include <cstring>
#include <cstdlib>
char st[100][100];
char s[100];
int n,m,l,flag;
bool find()
{
  int move[8][2];
  move[0][1]=-1;move[0][0]=-1;
  move[1][1]=0;move[1][0]=-1;
  move[2][1]=-1;move[2][0]=-1;
  move[3][1]=1;move[3][0]=0;
  move[4][1]=-1;move[4][0]=0;
  move[5][1]=-1;move[5][0]=1;
  move[6][1]=0;move[6][0]=1;
  move[7][1]=1; move[7][0]=1;
  int fx,k,xx,yy;
  bool mi;
  int i,j;
  for (i=0;i<n;i++)
    for (j=0;j<m;j++)
    {
      if (st[i][j]!=s[0])continue;
      for (fx=0;fx<=7;fx++)
      {
        xx=i;yy=j;mi=false;
        for (k=1;k<l;k++)
         {
           xx+=move[fx][0];
           yy+=move[fx][1];
           if (xx==-1||yy==-1||xx==n||yy==m)
             {mi=true;break;}                               
           if (st[xx][yy]!=s[k]) {mi=true;break;}
        }
        if (!mi) return true;
      }
    }
  return false;
}
int main()
{
  int i,j,k,x,y,t;
  memset(st,'\0',sizeof(st));
  memset(s,'\0',sizeof(s));
  freopen("input.txt","r",stdin);
  freopen("output.txt","w",stdout);
  scanf("%d%d",&n,&m);
  for (i=0;i<n;i++)
    scanf("%s",st[i]);
  scanf("%s",s);
  l=strlen(s);
  flag=find();
  if (flag) printf("сп\n");else printf("ц╩сп\n"); 
  return 0;    
}
