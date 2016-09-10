# ContactManager: my app for ASP MVC & Azure testing

# Getting started
- Clone
- Add missing secret files
    + /AppSettingsSecrets.config
    + /ContactManager/ApplicationInsights.config (TODO: is this secret? needed?)
    + /ContactManager/Properties/PublishProfiles/... (can get this from azure)
- Build
- Publish

# Notes
- Try to ensure master is always publish-able

--------------------------------------------------------------------------------
# Migrations
- NOTE: Migrations destroy data without asking - locally and on azure. Be careful!
    + See tag migration-destructive

## Careful azure migration process
- Optional: Do all of the following on a staging site to test the process
- Stop web app
- Restore azure database (creates duplicate database with new name) (TODO: duplicate instead of restore?)
- Publish app, applying migrations

## If things go wrong
### Publish previous version, point to DB backup
- Stop app
- Checkout previously published app version, publish
- Point app to the restored/duplicated database

### Alternative to DB backup
- Stop app
- Revert latest migration using

    Update-Database -TargetMigration <previous migration> -ConnectionString
    <get connection string from azure> -ConnectionProvider "System.Data.SqlClient"

- NOTE: publishing the previously deployed app does not reverse migrations,
  hence the above step
    + TODO: is there a way to reverse migrations when publishing old versions?
- Checkout previously published app version, publish

--------------------------------------------------------------------------------