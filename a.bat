git filter-branch --env-filter "
if [ \"$GIT_AUTHOR_NAME\" = \"鴇崎伸也\" ]; then
    export GIT_AUTHOR_NAME=\"nop40ns\";
    export GIT_AUTHOR_EMAIL=\"nop40ns@gmail.com\";
fi
if [ \"$GIT_COMMITTER_NAME\" = \"鴇崎伸也\" ]; then
    export GIT_COMMITTER_NAME=\"nop40ns\";
    export GIT_COMMITTER_EMAIL=\"nop40ns@gmail.com\";
fi
" --tag-name-filter cat -- --all