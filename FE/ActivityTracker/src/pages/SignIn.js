import React from 'react';
import {Image, StyleSheet, Text, View, SafeAreaView} from 'react-native';
import {Button} from 'react-native-paper';

function SignIn({navigation}) {
  return (
    <SafeAreaView style={styles.cntr}>
      <View style={styles.container}>
        <View>
          <Image style={styles.logo} source={require('../static/hero.png')} />
          <View style={{justifyContent: 'center', alignItems: 'center'}}>
            <Text
              style={{
                fontFamily: 'MysteryQuest-Regular',
                fontSize: 30,
                color: 'white',
                textAlign: 'center',
                fontWeight: '600',
              }}>
              TAP START TO START OUR JOURNEY
            </Text>
          </View>
        </View>
        <View style={styles.buttonStyle}>
          <Button
            mode="contained"
            contentStyle={styles.startButton}
            onPress={() => navigation.navigate('ChildSignIn')}>
            <Text
              style={{
                height: '100%',
                width: '100%',
                fontSize: 20,
                justifyContent: 'center',
                alignItems: 'center',
                fontWeight: '700',
              }}>
              S T A R T
            </Text>
          </Button>
        </View>
        <View
          style={{
            paddingTop: 100,
            justifyContent: 'space-between',
            flexDirection: 'row',
            width: '100%',
          }}>
          <Button
            mode="contained"
            style={{backgroundColor: 'gray'}}
            onPress={() => navigation.navigate('CreateAccount')}>
            <Text>Create Account</Text>
          </Button>
          <Button
            mode="contained"
            style={{backgroundColor: 'gray'}}
            onPress={() => navigation.navigate('SigninAdult')}>
            <Text>Sign In</Text>
          </Button>
        </View>
      </View>
    </SafeAreaView>
  );
}

export default SignIn;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'space-around',
    flexDirection: 'column',
    width: '80%',
    height: '80%',
    paddingBottom: 100,
  },
  buttonStyle: {
    width: 250,
  },
  startButton: {
    paddingVertical: 40,
  },
  logo: {
    width: 300,
    height: 300,
  },
  cntr: {
    flex: 1,
    backgroundColor: '#98D8AA',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
