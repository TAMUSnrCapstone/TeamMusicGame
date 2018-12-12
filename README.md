# Fantastic Beats
## ENGR 482 Fall 2018 Capstone

Ryan Branson

Natalie Cluck

Jacob Jones

Jack Long

Clayton Wells


## Git Notes

Out of habit, use these commands often before making changes:

```
git fetch
git pull
```

To see your latest changes (helps to do this before add/commit/push):

```
git status
```

To push changes to the repo:

```
git add *
git commit -a -m "[your message here]"
git push
```

To create a new branch (keep the name short):

```
git checkout -b [name of new branch]
```

To delete a local branch:

```
git branch -d [name of local branch]
```

To delete a remote branch:

```
git push origin --delete [name of remote branch]
```

Anytime .gitignore is updated, or just not working:

```
git rm -rf --cached .
git add .
git commit -a -m "gitignore now working"
```

To completely reset your local branch to equal the remote (approach with caution - deletes all your changes):

```
git fetch origin
git reset --hard origin/[name of branch]
```

##Notes about current code
Unity will run this project successfully on a Windows machine. We have not been able to check the integrity of running the project on a Mac(The project, not the game itself).

If you actually want to build the game, you will need to switch over to the noUnitTests branch. Unit tests prevent build from being made(known issue with unity at the moment). The branch has all unit tests removed, allowing builds to be made.
