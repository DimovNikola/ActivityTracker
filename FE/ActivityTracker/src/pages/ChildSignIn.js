import React from 'react';
import {
  SafeAreaView,
  View,
  Text,
  StyleSheet,
  Image,
  KeyboardAvoidingView,
} from 'react-native';
import {Button, TextInput} from 'react-native-paper';

function ChildSignIn({navigation}) {
  return (
    <KeyboardAvoidingView style={styles.cntr}>
      <SafeAreaView style={styles.cntr}>
        <View style={styles.container}>
          <Image style={styles.logo} source={require('../static/hero.png')} />
          <View style={{width: '70%', paddingBottom: 100}}>
            <Text
              style={{
                fontSize: 30,
                fontFamily: 'MysteryQuest-Regular',
                color: 'white',
                textAlign: 'center',
              }}>
              Tap the yellow boxes to enter your name and password
            </Text>
            <TextInput
              style={{backgroundColor: '#F3E99F'}}
              placeholder="What is your name?"
            />
            <View style={{paddingBottom: 10}}></View>
            <TextInput
              style={{backgroundColor: '#F3E99F'}}
              secureTextEntry={true}
              placeholder="What is your password?"
            />
          </View>
          <View
            style={{
              justifyContent: 'center',
              flexDirection: 'row',
              alignItems: 'center',
              width: '100%',
              paddingBottom: 120,
            }}>
            <Button
              mode="contained"
              icon="arrow-left"
              contentStyle={{width: 100, height: 90}}
              labelStyle={{fontSize: 30, fontWeight: 'bold'}}
              onPress={() => navigation.navigate('SignIn')}></Button>
            <View style={{paddingLeft: 50}}></View>
            <Button
              mode="contained"
              icon="star"
              contentStyle={{
                width: 200,
                height: 90,
              }}
              labelStyle={{fontSize: 16, textAlign: 'center'}}
              onPress={() => navigation.navigate('ChildHomePage')}>
              LETS GET STARTED
            </Button>
            <View style={{paddingRight: 15}}></View>
          </View>
        </View>
      </SafeAreaView>
    </KeyboardAvoidingView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    flexDirection: 'column',
    width: '100%',
    height: '80%',
    justifyContent: 'space-around',
  },
  cntr: {
    flex: 1,
    backgroundColor: '#98D8AA',
    alignItems: 'center',
    justifyContent: 'center',
  },
  logo: {
    width: 250,
    height: 250,
  },
});

export default ChildSignIn;
